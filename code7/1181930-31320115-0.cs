    public class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("Performing base class drawing tasks");
        }
    }
    
    class Circle : Shape
    {
        public override void Draw()
        {
            // Code to draw a circle...
            Console.WriteLine("Drawing a circle");
        }
    }
    class Rectangle : Shape
    {
        public override void Draw()
        {
            // Code to draw a rectangle...
            Console.WriteLine("Drawing a rectangle");
        }
    }
   
    
    List<Shape> shapes = new List<Shape>();
    shapes.Add(new Rectangle());
    shapes.Add(new Circle());
     
    foreach (Shape s in shapes)
    {
        s.Draw();
    }
