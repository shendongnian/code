    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    namespace CallBackFromCpp
    {
        public partial class Form1 : Form
        {
            public event EventHandler StartEvent;
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                if (StartEvent != null)
                    StartEvent(this, e);
            }
            
            private void button2_Click(object sender, EventArgs e)
            {
                if (StopEvent != null)
                    StopEvent(this, e);
            }
        }
    }
