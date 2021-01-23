    public class Line : IShape
    {
        public Line() { LineWidth = 2; LineColor = Color.Black; }
        public int LineWidth { get; set; }
        public Color LineColor { get; set; }
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public GraphicsPath GetPath()
        {
            var path = new GraphicsPath();
            path.AddLine(Point1, Point2);
            return path;
        }
        public bool HitTest(Point p)
        {
            var result = false;
            using (var path = GetPath())
            using (var pen = new Pen(LineColor, LineWidth + 2))
                result = path.IsOutlineVisible(p, pen);
            return result;
        }
        public void Draw(Graphics g)
        {
            using (var path = GetPath())
            using (var pen = new Pen(LineColor, LineWidth))
                g.DrawPath(pen, path);
        }
        public void Move(Point d)
        {
            Point1 = new Point(Point1.X + d.X, Point1.Y + d.Y);
            Point2 = new Point(Point2.X + d.X, Point2.Y + d.Y);
        }
    }
