    protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                roundedRect = new RoundedRectangle(Width, Height, radius);
    
                if (state == MouseState.Leave)
                    using (LinearGradientBrush inactiveGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), inactive1, inactive2, 90f))
                        e.Graphics.FillPath(inactiveGB, roundedRect.Path);
                else if (state == MouseState.Over)
                    using (LinearGradientBrush activeGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), active1, active2, 90f))
                        e.Graphics.FillPath(activeGB, roundedRect.Path);
    
                using (LinearGradientBrush BorderGB = new LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(162, 120, 101), Color.FromArgb(162, 120, 101), 90f))
                    e.Graphics.DrawPath(new Pen(BorderGB), roundedRect.Path);
            }
            protected override void OnResize(EventArgs e)
            {
                Invalidate();
                base.OnResize(e);
            }
            protected override void OnMouseEnter(EventArgs e)
            {
                state = MouseState.Over;
                Invalidate();
                base.OnMouseEnter(e);
            }
