    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace TestProgressBar
    {
        public class MyProgressBar : ProgressBar
        {
            public MyProgressBar() : base()
            {
                Draw += (sender, e) =>
                {
                    e.Graphics.DrawString(Value + " / " + MaximumValue, new Font("Arial", (float) 10.0, FontStyle.Regular), Brushes.Black, new PointF(Width / 2 - 10, Height / 2 - 7));//you can also use the Font property as the font
                };
            }
        }
    }
