     int x = 0, y = 0;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
           
            // Save the mouse coordinates
            x = e.X; y = e.Y;
            
            // Force to invalidate the form client area and immediately redraw itself. 
            Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            base.OnPaint(e);
            Pen p = new Pen(Color.Navy);
            g.DrawLine(p, 0, 0, x, y);
        }
