    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            List<TextBox> textBoxes = null;
            public Form1()
            {
                InitializeComponent();
                textBoxes = new List<TextBox>() { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 };
                for (int i = 0; i < textBoxes.Count - 1; i++)
                {
                    int iInt = int.Parse(textBoxes[i].Text);
                    for (int j = i + 1; j < textBoxes.Count; j++)
                    {
                        int jInt = int.Parse(textBoxes[j].Text);
                        if (jInt < iInt)
                        {
                            iInt = int.Parse(textBoxes[j].Text);
                            string temp = textBoxes[i].Text;
                            textBoxes[i].Text = textBoxes[j].Text;
                            textBoxes[j].Text = temp;
                        }   
                    }
                }
            }
        }
    }
    ​
