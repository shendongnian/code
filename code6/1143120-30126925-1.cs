    protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            
            Color fillColor = MouseHovering ? Color.DarkSlateGray : Color.Gray;
            
            using (Pen p = new Pen(Color.Black, 2))
            using (Brush b = new SolidBrush(fillColor))
            {
                Rectangle fillRect = new Rectangle (0, 0, this.Width, this.Height);
    
                g.DrawRectangle (p, e.ClipRectangle);
            }
        }
