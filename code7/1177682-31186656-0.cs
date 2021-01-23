    namespace Photoviewer
    {
        public partial class Form1 : Form
        {
            int anselct = 0;
            //bool buttonclick = false;
            //bool runme = true;
    
    
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
                    if (A1.Checked)
                    {                       
                        Q1.Text = Q1.Text.Replace("Hello, welcome to the Geography quiz. Press 'A' and then 'Enter' to begin the quiz.", "Question 1: What is the capital of Cuba"); //Changes text to that of the first question
                        A1.Text = A1.Text.Replace("A", "Greenwich");
                        A2.Text = A2.Text.Replace("B", "Berlin");
                        A3.Text = A3.Text.Replace("C", "Bogota");
                        A4.Text = A4.Text.Replace("D", "Havana");
                       
                    }
            }  //end of Button_Click_1
        }
    }
