    protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.Aqua, Color.Blue, 90);
            using (GraphicsPath gp = new GraphicsPath())
            {
                AddRoundedRectangle(gp, new Point(1, 1), new Size(this.Size.Width - 2, Size.Height - 2));
                e.Graphics.FillPath(brush, gp);
            }
            using (GraphicsPath gp = new GraphicsPath())
            {
                AddRoundedRectangle(gp, new Point(0, 0), this.Size);
                this.Region = new Region(gp);
            }
            base.OnPaint(e);
        }
        private void AddRoundedRectangle(GraphicsPath gp, Point upperLeft, Size size)
        {
            gp.AddArc(new Rectangle(upperLeft, new Size(size.Height, size.Height)), 90, 180);
            gp.AddLine(new Point(size.Height / 2 , upperLeft.Y), new Point(size.Width - (size.Height / 2), upperLeft.Y));
            gp.AddArc(new Rectangle(new Point(size.Width - size.Height, upperLeft.Y), new Size(size.Height, size.Height)), -90, 180);
            gp.CloseFigure();
        }
