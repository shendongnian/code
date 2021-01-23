    public class Circle
    {
        private Color selectedFillColor = Color.Red;
        private Color normalFillColor = Color.Red;
        private Color borderColor = Color.Red;
        private int borderWidth = 2;
        public Point Location { get; set; }
        public int Diameter { get; set; }
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle(Location, new Size(Diameter, Diameter));
            }
        }
        public bool HitTest(Point p)
        {
            var result = false;
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(Bounds);
                result = path.IsVisible(p);
            }
            return result;
        }
        public bool Selected { get; set; }
        public void Draw(Graphics g)
        {
            using (var brush = new SolidBrush(
                Selected ? selectedFillColor : normalFillColor))
                g.FillEllipse(brush, Bounds);
            using (var pen = new Pen(borderColor, 2))
                g.DrawEllipse(pen, Bounds);
        }
    }
