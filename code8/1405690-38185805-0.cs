    class DialLabel : Label
    {
        public DialLabel()
        {
            AutoSize = false;
            NeedleColor = Color.Red;
            NeedleWidth = 3f;
        }
        public Color NeedleColor { get; set; }
        public float NeedleWidth { get; set; }
        public string Format { get; set; }
        public decimal MaxValue { get; set; }
        public decimal Value { get; set; }
        float angle { get { return 180f / 100f * (float)(MaxValue - Value); } }
        protected override void OnPaint(PaintEventArgs e)
        {
            Point center = new Point(Width / 2, (Height - 25)); // 25 pixels for text
            Rectangle textbox = new Rectangle(1, Height - 25, Width, 25);
            TextRenderer.DrawText(e.Graphics, Value.ToString(Format), Font,
                                  textbox, ForeColor, BackColor);
            float nx = Width / 2f + 
                      (Width / 2f - 2) * (float)Math.Cos(angle * Math.PI / 180f);
            float ny = (Height - 25) - 
                       (Width / 2f - 2) * (float)Math.Sin(angle * Math.PI / 180f);
            using (Pen pen = new Pen(NeedleColor, NeedleWidth))
                e.Graphics.DrawLine(pen, center.X, center.Y, nx, ny);
        } 
    }
