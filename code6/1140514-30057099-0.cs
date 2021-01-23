    public class MyLovelyProgressBar : ProgressBar
    {
        public MyLovelyProgressBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        private string foregroundText;
        public string ForegroundText 
        {
            get { return foregroundText;  }
            set 
            {
                if (foregroundText != value)
                {
                    Invalidate();
                    foregroundText = value;
                }
            } 
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case 15: //WmPaint
                    using (var graphics = Graphics.FromHwnd(Handle))
                        PaintForeGroundText(graphics);
                    break;
            }
        }
        private void PaintForeGroundText(Graphics graphics)
        {
            if (!string.IsNullOrEmpty(ForegroundText))
            {
                var size = graphics.MeasureString(ForegroundText, this.Font);
                var point = new PointF(Width / 2.0F - size.Width / 2.0F, Height / 2.0F - size.Height / 2.0F);
                graphics.DrawString(ForegroundText, this.Font, new SolidBrush(Color.Black), point);
            }
        }
    }
