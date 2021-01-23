    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    namespace Flicker
    {
        public partial class Form1 : Form
        {
            Stopwatch stopwatch = new Stopwatch();
    
            public Form1()
            {
                InitializeComponent();
    
                stopwatch.Start();
            }
    
            public void UpdateFrame()
            {
                double cycleHz = 0.001;
    
                double wave = Math.Sin((stopwatch.ElapsedMilliseconds * 2.0 * Math.PI) * cycleHz);
    
                if (wave > 0.0)
                {
                    pictureBox1.BackColor = System.Drawing.Color.Black;
                }
                else
                {
                    pictureBox1.BackColor = System.Drawing.Color.White;
                }
            }
        }
    }
