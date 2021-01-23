    public class DrawingSurface : Control
    {
        public List<IShape> Shapes { get; private set; }
        IShape selectedShape;
        bool moving;
        Point previousPoint = Point.Empty;
        public DrawingSurface() { DoubleBuffered = true; Shapes = new List<IShape>(); }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            for (var i = Shapes.Count - 1; i >= 0; i--)
                if (Shapes[i].HitTest(e.Location)) { selectedShape = Shapes[i]; break; }
            if (selectedShape != null) { moving = true; previousPoint = e.Location; }
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (moving) {
                var d = new Point(e.X - previousPoint.X, e.Y - previousPoint.Y);
                selectedShape.Move(d);
                previousPoint = e.Location;
                this.Invalidate();
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (moving) { selectedShape = null; moving = false; }
            base.OnMouseUp(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var shape in Shapes)
                shape.Draw(e.Graphics);
        }
    }
