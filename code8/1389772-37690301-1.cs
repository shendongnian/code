    // Custom paint progressbar
    public class ProgressBarWithTitle : ProgressBar
    {
        private Brush _barBrush;
        public ProgressBarWithTitle()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            _barBrush = new SolidBrush(this.ForeColor);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var rect = new RectangleF(0, 0, (float)(this.Width * (Value - Minimum) / Maximum), this.Height);
            e.Graphics.FillRectangle(_barBrush, rect);
            var valueString = base.Value.ToString() + "%";
            var textSize = e.Graphics.MeasureString(valueString, SystemFonts.DefaultFont);
            e.Graphics.DrawString(
                valueString,
                SystemFonts.DefaultFont,
                Brushes.Black,
                new PointF(
                    (Width / 2) - ((int)textSize.Width / 2),
                    (Height / 2) - ((int)textSize.Height / 2)));
        }
    }
