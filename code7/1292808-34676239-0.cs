    public class Oval
    {
        private double Width { get; }
        private double Height { get; }
        public double Area { get { ... } };
        public Oval(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
    public class Circle
    {
        public double Radius { get { return Height; } }
        public Circle(double radius) : base(radius)
        {
        }
    }
