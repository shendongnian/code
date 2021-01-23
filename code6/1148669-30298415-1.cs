    class Ellipse : Control
    {
        Point mDown { get; set; }
        public Ellipse()
        {
            MouseDown += shape_MouseDown;
            MouseMove += shape_MouseMove;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillEllipse(Brushes.Black, this.Bounds);
        }
        private void shape_MouseDown(object sender, MouseEventArgs e)
        {
            mDown = e.Location;
        }
        private void shape_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Location = new Point(e.X + Left - mDown.X, e.Y + Top - mDown.Y);
            }
        }
    }
    
