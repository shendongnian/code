    public class MyPanel : Panel
    {
        public MyPanel()
        {
            this.Padding = new Padding(2);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = new GraphicsPath())
            {
                var d = this.Padding.All;
                var r = this.Height - 2 * d;
                path.AddArc(d, d, r, r, 90, 180);
                path.AddArc(this.Width - r - d, d, r, r, -90, 180);
                path.CloseFigure();
                using (var pen = new Pen(Color.Silver, d))
                    e.Graphics.DrawPath(pen, path);
            }
        }
    }
