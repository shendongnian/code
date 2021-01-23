    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            private Point p;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void NotifyIcon1_MouseMove(object sender, MouseEventArgs e)
            {
                p = Cursor.Position;
                if(!timer1.Enabled)
                {
                    timer1.Start();
                }
            }
    
            private void Timer1_Tick(object sender, EventArgs e)
            {
                if(Cursor.Position != p)
                {
                    //The mouse now left the notify icon
                    //Write the code you want to execute when mouse leave the notify icon
                    timer1.Stop();
                }
            }
        }
    }
