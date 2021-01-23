    using System;
    using System.Windows.Forms;
    class Form1 : Form
    {
        public Form1()
        {
            var timer = new Timer() { Interval = 1000 };
            this.Text = "Some Text";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            timer.Tick += (x, y) =>
            {
                if (this.WindowState != FormWindowState.Minimized)
                    this.WindowState = FormWindowState.Minimized;
                else
                    this.WindowState = FormWindowState.Normal;
            };
            timer.Start();
        }
    }
