﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Media;

namespace Animals
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            if (radDog.Checked == true)
            {
                //Notice how it first says "Animal" then says "new Dog" this is important, essentially says that I want to create a dog, which inherits all the properties of Animal
                Animal doggo1 = new Dog();

                doggo1.name = Interaction.InputBox("Enter your dog's name");
                doggo1.color = Interaction.InputBox("Enter your dog's color");
                doggo1.weight = Convert.ToDouble(Interaction.InputBox("Enter your dog's weight"));

                lblOutput.Text = doggo1.ToString();
                doggo1.Noise();
            }
            else if (radCat.Checked == true)
            {
                Animal cato1 = new Cat();

                cato1.name = Interaction.InputBox("Enter your cat's name");
                cato1.color = Interaction.InputBox("Enter your cat's color");
                cato1.weight = Convert.ToDouble(Interaction.InputBox("Enter your cat's weight"));

                lblOutput.Text = cato1.ToString();
                cato1.Noise();
            }
            else if (radBird.Checked == true)
            {
                Animal birb1 = new Bird();

                birb1.name = Interaction.InputBox("Enter your bird's name");
                birb1.color = Interaction.InputBox("Enter your bird's color");
                birb1.weight = Convert.ToDouble(Interaction.InputBox("Enter your bird's weight"));

                lblOutput.Text = birb1.ToString();
                birb1.Noise();
            }
        }
    }

//CTORRs
//Notice, that #region is used. It allows for easier organization of the code
//Notice, all the other classes "Inherit" the main Animal class

    #region Animal
    class Animal
    {
        public string name { get; set; }
        public string color { get; set; }
        public double weight { get; set; }

        //Sets default data
        public Animal(string name = "Animal", string color = "Color", double weight = 0)
        {
            this.name = name;
            this.color = color;
            this.weight = weight;
        }

        //This allows for an easier way of printing the attributes of the object
        public override string ToString()
        {
            return String.Format("\n\nName: {0} \nColor: {1}, \nWeight: {2}", name, color, weight);
        }

        //MUST BE A VIRTUAL VOID - Virtual voids essentially say "I'm here but I can be overwritten"
        public virtual void Noise() 
        {
            return;
        }
    }
    #endregion

    #region Dog : Animal
    //Notice how it goes Dog : Animal. This means that Dog inherits all the information that Animal has, hence why it has no get/set
    //Programmers are lazy, this is the way that programmers prevent themselves from having to repeat the same "Get, Set" and methods for similar objects
    class Dog : Animal
    {
        //MUST BE AN OVERRIDE VOID - Override voids say "This is the new functionality, use it"
        //Allows for every animal to make a different noise, as this method overrides the virtual void on line 86
        public override void Noise()
        {
            //A folder was added to the debug folder with all the .wav files to allow for only having to do "res/DogBark.wav" instead of a full file path
            SoundPlayer bark = new SoundPlayer(@"res/DogBark.wav");
            bark.Play();
        }
    }
    #endregion

    #region Cat : Animal
    class Cat : Animal
    {
        public override void Noise()
        {
            SoundPlayer meow = new SoundPlayer(@"res/CatMeow.wav");
            meow.Play();
        }
    }
    #endregion 

    #region Bird : Animal
    class Bird : Animal
    {
        public override void Noise()
        {
            SoundPlayer tweet = new SoundPlayer(@"res/Borb.wav");
            tweet.Play();
        }
    }
    #endregion 
}
