    public void moveToPosition(double x, double y) {
            resize();
            Point center = new Point(this.Width / 2, this.Height / 2);
            border.PanToPosition(x, y, center);
            Point p = new Point(x, y);
            Matrix m = canvasWaSNA.RenderTransform.Value;
            m.ScaleAtPrepend(6, 6, p.X, p.Y);
            canvasWaSNA.RenderTransform = new MatrixTransform(m);
        }
