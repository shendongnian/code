    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Windows.Input;
    namespace hmmmhmh
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Timer timer = new Timer();
                timer.Interval = 1;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Enabled = true;
            }
            private void timer_Tick(object sender, EventArgs e)
            {
                if (Control_Pressed && F_Pressed)
                {
                    button1_Click(sender, e);
                }
            }
            private bool Control_Pressed
            {
                get
                {
                    return Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
                }
            }
            private bool F_Pressed
            {
                get
                {
                    return Keyboard.IsKeyDown(Key.E);
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("hlhlh");
            }
        }
    }
