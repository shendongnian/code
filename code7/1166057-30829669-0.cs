    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                timer1.Tick += new EventHandler(timer1_Tick);
            }
            static AutoResetEvent autoEvent = new AutoResetEvent(false);
            private void gen_Sinus(double frequency)
            {
                WaveOut _myWaveOut = new WaveOut();
                SignalGenerator mySinus = new SignalGenerator(44100, 1);//using NAudio.Wave.SampleProviders; 
                mySinus.Frequency = frequency;
                mySinus.Type = SignalGeneratorType.Sin;
                _myWaveOut.Init(mySinus);
                timer1.Interval = 5000;
                timer1.Start()
                _myWaveOut.Play();
                autoEvent.Reset();
                autoEvent.WaitOne();
                _myWaveOut.Stop();
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                autoEvent.Set();
                
            }
        }
    }
    ​
