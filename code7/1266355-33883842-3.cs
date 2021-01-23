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
            List<int> numbers = new List<int>();
            List<Label> labels = null;
            public Form1()
            {
                InitializeComponent();
                textBoxes = new List<TextBox>() { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10 };
                labels = new List<Label>() { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10 };
                for (int i = 0; i < textBoxes.Count; i++)
                {
                     numbers.Add(int.Parse(textBoxes[i].Text));
                }
                numbers = numbers.OrderBy(x => x).ToList();
                for (int i = 0; i < numbers.Count; i++)
                {
                    labels[i].Text = numbers.ToString();
                }
            }
        }
    }
    ​
