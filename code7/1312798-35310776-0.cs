    public void PanToPosition(double x, double y, Point center) {
            if (child != null)
            {
                var tt = GetTranslateTransform(child);
                start = new Point(x,y);
                Point p = new Point(center.X, center.Y);
                origin = new Point(tt.X, tt.Y);
                Vector v = start - p;
                tt.X = origin.X - v.X;
                tt.Y = origin.Y - v.Y;
            }
        }
