    public abstract class Shape
    {
        public abstract double Area { get; }
        public abstract double Perimeter { get; }
    }
    public class Oval
    {
        private double Width { get; }
        private double Height { get; }
        public override double Area { get { ... } };
        public override double Perimeter { get { ... } };
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
