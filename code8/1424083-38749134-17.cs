    public class Circle : IShape
    {
        public Circle() { FillColor = Color.Black; }
        public Color FillColor { get; set; }
        public Point Center { get; set; }
        public int Radious { get; set; }
        public GraphicsPath GetPath()
        {
            var path = new GraphicsPath();
            var p = Center;
            p.Offset(-Radious, -Radious);
            path.AddEllipse(p.X, p.Y, 2 * Radious, 2 * Radious);
            return path;
        }
        public bool HitTest(Point p)
        {
            var result = false;
            using (var path = GetPath())
                result = path.IsVisible(p);
            return result;
        }
        public void Draw(Graphics g)
        {
            using (var path = GetPath())
            using (var brush = new SolidBrush(FillColor))
                g.FillPath(brush, path);
        }
        public void Move(Point d)
        {
            Center = new Point(Center.X + d.X, Center.Y + d.Y);
        }
    }
