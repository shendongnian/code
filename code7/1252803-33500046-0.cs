    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace TestSO {
    
        public partial class Form1 : Form {
            public Form1() { }
    
            PointF p1 = new PointF(10, 10);
            PointF p2 = new PointF(170, 30);
    
            float durationMS = 5000;
            float stepMS = 100;
    
            float stepWidthX;
            float k;
            float d;
    
            private Timer tmr = new Timer();
    
            protected override void OnLoad(EventArgs e) {
                base.OnLoad(e);
    
                stepWidthX = (p2.X-p1.X)/ (durationMS / stepMS);
    
                k = (p2.Y - p1.Y) / (p2.X - p1.X);
                d = (p2.X * p1.Y - p1.X * p2.Y) / (p2.X - p1.X);
                
                tmr.Tick += tmr_Tick;
                tmr.Interval = (int)stepMS;
                tmr.Start();
            }
    
            private int stepCounter = 0;
            void tmr_Tick(object sender, EventArgs e) {
                stepCounter++;
    
                float x = p1.X + stepCounter * stepWidthX;
                float y = k * x + d;
                this.CreateGraphics().DrawLine(Pens.Black, p1, new PointF(x, y));
    
    
                if(stepCounter * stepMS > durationMS){
                    stepCounter = 0;
                    tmr.Stop();
                    this.CreateGraphics().DrawLine(Pens.Red, p1, p2);
                }
            }
    
        }
    }
