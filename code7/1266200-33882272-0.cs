    protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
    
                LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.Aqua, Color.Blue, 90);
    
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddArc(new Rectangle(new Point(0, 0), new Size(this.Height, this.Height)), 90, 180);
                    gp.AddLine(new Point(this.Height / 2, 0), new Point(this.Width - (this.Height / 2), 0));
                    gp.AddArc(new Rectangle(new Point(this.Width - this.Height, 0), new Size(this.Height, this.Height)), -90, 180);
                    gp.CloseFigure();
    
                    e.Graphics.FillPath(brush, gp);
                }
    
                base.OnPaint(e);
            }
