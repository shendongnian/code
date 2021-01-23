    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows;
    using System.Windows.Input;
    namespace Photoviewer
    {
        public partial class Form1 : Form
        {
            int anselct = 0;
            bool runme = true;
    
    
            public Form1()
            {
                InitializeComponent();
                Q1.Text = Q1.Text.Replace("null", "Hello, welcome to the Geography quiz. Press 'A' and then 'Enter' to begin the quiz."); //replaces base text with introduction
                A1.Text = A1.Text.Replace("radioButton1", "A");
                A2.Text = A2.Text.Replace("radioButton3", "B");
                A3.Text = A3.Text.Replace("radioButton4", "C");
                A4.Text = A4.Text.Replace("radioButton2", "D");
                
            }
    
    //various irrelevant things are here
    
            public void Button_Click_1(object sender, EventArgs e)
            {
    			//do {
                    if (A1.Checked)
                    {
                        Q1.Text = Q1.Text.Replace("Hello, welcome to the Geography quiz. Press 'A' and then 'Enter' to begin the quiz.", "Question 1: What is the capital of Cuba"); //Changes text to that of the first question
                        A1.Text = A1.Text.Replace("A", "Greenwich");
                        A2.Text = A2.Text.Replace("B", "Berlin");
                        A3.Text = A3.Text.Replace("C", "Bogota");
                        A4.Text = A4.Text.Replace("D", "Havana");
                        //runme = false;
                    } //end of if statement
               //} while (runme == true); //end of do loop, should be infinate unless told to close
            }  //end of Button_Click_1
        }
    }
