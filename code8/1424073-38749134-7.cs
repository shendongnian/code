    public class RectangleShape : Shape
    {
        public Point Location { get; set; }
        public Size Size { get; set; }
        protected override GraphicsPath GetPath()
        {
            var path = new GraphicsPath();
            path.AddRectangle(new Rectangle(Location, Size));
            return path;
        }
        public override void Move(Point d)
        {
            Location = new Point(Location.X + d.X, Location.Y + d.Y);
        }
    }
