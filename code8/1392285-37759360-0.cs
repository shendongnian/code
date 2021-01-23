    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Imagebox_test1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    KeyPreview = true; 
            }
    
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                int x = pictureBox1.Location.X;
                int y = pictureBox1.Location.Y;
    
                if (e.KeyCode == Keys.D) x += 1;
                else if (e.KeyCode == Keys.A) x -= 1;
                else if (e.KeyCode == Keys.W) y -= 1;
                else if (e.KeyCode == Keys.S) y += 1;
    
                pictureBox1.Location = new Point(x, y);
            }
        }
    }
