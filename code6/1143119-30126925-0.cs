    protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            g.SmoothingMode = SmoothingMode.HighQuality;
            Pen p = new Pen (Color.Black, 2);
            Rectangle fillRect = new Rectangle (e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
            Brush b;
            if (MouseHovering)
            {
                b = new SolidBrush (Color.DarkSlateGray);
            } 
            else
            {
                b = new SolidBrush (Color.Gray);
            }
            //g.FillRectangle (b, fillRect);
            g.DrawRectangle (p, e.ClipRectangle);
            //g.DrawString (Text, new Font ("Arial", 8), new SolidBrush (Color.Black), new Point (4, 4));
            b.Dispose();   //ADD THIS
            p.Dispose();   //ADD THIS TOO
        }
