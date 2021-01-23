    namespace NaiveFactory
    {
    
        public interface Shape
        {
            void Draw();
        }
    
        public class Circle : Shape
        {
            public void Draw() { Console.WriteLine("Drawing Circle"); }
        }
    
        public class Rectangle : Shape
        {
            public void Draw() { Console.WriteLine("Drawing Rectangle"); }
        }
    
        public class ShapeFactory
        {
            public static Shape GetShape<T>() where T : Shape
            {
                return Activator.CreateInstance<T>();
            }
    
            public static Shape GetShape(string shapeName)
            {
                var assembly = Assembly.GetExecutingAssembly();
                var type = assembly.GetType(shapeName).FullName;
                return (Shape) Activator.CreateInstanceFrom(assembly.Location, type).Unwrap();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var shape = ShapeFactory.GetShape<Circle>();
                var shape2 = ShapeFactory.GetShape("NaiveFactory.Rectangle");
                shape.Draw();
                shape2.Draw();
                Console.ReadKey();
            }
        }
    }
