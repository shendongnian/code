    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace EventsTry
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                CountDown CountDown = new CountDown(new DateTime(2016,06,01,11,35,00));
                CountDown.CountDownFinish += new countDownFinishEventHandler(onCountDown);
                CountDown.TimeLeftChanged += new TimeLeftChangedEventHandler(onTimeLeft);
                CountDown.CountDownStart();
            }
    
            private void onCountDown(Object sender, EventArgs e)
            {
                MessageBox.Show("time expired! ");
            }
    
            private void onTimeLeft(Object sender, TimeLeftDateEventArgs e)
            {
                label1.Text = e.Hours + ":" + e.Minutes + ":" + e.Seconds;
            }
        }
    }
