    public sealed class MyPanel: Panel
    {
        public MyPanel()
        {
            this.ResizeRedraw = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var brush = new SolidBrush(this.ForeColor))
            {
                e.Graphics.FillEllipse(brush, 0, 0, this.Width, this.Height);
            }
        }
    }
