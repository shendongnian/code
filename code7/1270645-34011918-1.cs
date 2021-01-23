    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.IO;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            List<string> matchedList = new List<string>();
            public Form1(string citation)
            {
                InitializeComponent();
                string filePath = @"C:\Users\rfranklin\Documents\ProjectData.txt";
                string[] linesArr = File.ReadAllLines(filePath);
                //find matches
                foreach(string s in linesArr)
                {
                    if(s.Contains(citation))
                    {
                        matchedList.Add(s); //matched
                    }
                }
                //output
                foreach(string s in matchedList)
                {
                    Console.WriteLine(s); //write to console
                    //or output to wherever you wish, eg.
                    //richTextBox.Text += s + "\n";
                }
            }
        }
    }
