    class ExtendedButton : Button
    {
        public enum ExtendedStyle
        {
            Red,
            Blue
        }
        private static ExtendedStyle style;
        public ExtendedStyle Style
        {
            get { return style; }
            set { style = value; }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (style == ExtendedStyle.Red)
                pe.Graphics.DrawRectangle(Pens.Red, 0, 0, Width - 1, Height - 1);
            else
                pe.Graphics.DrawRectangle(Pens.Blue, 0, 0, Width - 1, Height - 1);
        }
    }
