    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml.Linq;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            int[] randomNumbers;
            public Form1()
            {
                InitializeComponent();
                randomNumbers = GenerateRandomNumbers();
            }
            int[] GenerateRandomNumbers()
            {
                Random rnd = new Random();
                return Enumerable.Range(1, 90).OrderBy(i => rnd.Next()).ToArray();
            }
            string space = " ";
            int number;
            void button1_Click(object sender, EventArgs e)
            {
                int[] array = randomNumbers;
                for (int i = 0; i < 90; i++)
                {
                    richTextBox1.Text += randomNumbers[i].ToString() + space;
                    richTextBox2.Text += array[i].ToString() + space;
                    number = array[i];
                }
                textBox1.Text += number.ToString() + space;
                textBox2.Text += textBox1.Text;
                textBox1.Clear();
            }
        }
    }
