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
            public Form1()
            {
                InitializeComponent();
                Button[] Tombol = new Button[]{B1, B2, B3};
                int counterbutton = 0;
                B1.BackColor = Color.Red;
                B3.BackColor = Color.Red;
                foreach (Button b in Tombol)
                {
                    if(b.BackColor == Color.Red) //I have problem here. I don't know how to solve
                    {
                        counterbutton++;
                    }
                }
            }
        }
    }
