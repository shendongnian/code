    public class Shape
    {
        public virtual void Display()
        {
            Console.WriteLine("I am a Shape");
        }
        public void BaseClassMethod()
        {
            Console.WriteLine("I am Base Class Method");
        }
    }
    public class Square : Shape
    {
        public override void Display()
        {
            Console.WriteLine("I am Square");
        }
        public void DerivedClassMethod()
        {
            Console.WriteLine("I am Derived Class Method");
        }
    }
    public class Circle : Shape
    {
        public override void Display()
        {
            Console.WriteLine("I am Circle");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape();
            shapes.Add(new Square());
            shapes.Add(new Circle());
