    namespace NaiveFactory
    {
        public interface IBoard
        {
            void InternalDraw(string str);
        }
    
        public class ConsoleBoard : IBoard
        {
            public void InternalDraw(string str) { Console.WriteLine(str); }
        }
    
        public class DebugBoard : IBoard
        {
            public void InternalDraw(string str) { Debug.WriteLine(str); }
        }
    
        public interface Shape
        {
            IBoard Board { get; set; }
            void Draw();
            void SetBoard(IBoard board);
        }
    
        public class Circle : Shape
        {
            public IBoard Board { get; set; }
    
            public Circle()
            {
                
            }
    
            public Circle(IBoard board)
            {
                Board = board;
            }
    
            public void Draw() { Board.InternalDraw("Drawing Circle"); }
    
            public void SetBoard(IBoard board)
            {
                Board = board;
            }
        }
    
        public class Rectangle : Shape
        {
            public IBoard Board { get; set; }
    
            public Rectangle()
            {
    
            }
    
            public Rectangle(IBoard board)
            {
                Board = board;
            }
    
            public void Draw() { Board.InternalDraw("Drawing Rectangle"); }
    
            public void SetBoard(IBoard board)
            {
                Board = board;
            }
        }
    
        public class ShapeFactory
        {
            private static Dictionary<Type, Type> _configurationData = new Dictionary<Type, Type>();
    
            public static Shape GetShape<T>() where T : Shape
            {
                return Activator.CreateInstance<T>();
            }
    
            public static void ConfigureContainer<T, U>()
            {
                _configurationData.Add(typeof(T), typeof(U));
            }
    
            public static Shape GetShape_UsingConstructorInjection(string shapeName)
            {
                var assembly = Assembly.GetExecutingAssembly();
                var type = assembly.GetType(shapeName);
                var constructor = type.GetConstructor(_configurationData.Keys.ToArray());
                if (constructor != null)
                {
                    var parameters = constructor.GetParameters();
                    return (from parameter in parameters where _configurationData.Keys.Contains(parameter.ParameterType) 
                            select Activator.CreateInstance(_configurationData[parameter.ParameterType]) into boardObj 
                            select (Shape) Activator.CreateInstance(type, boardObj)).FirstOrDefault();
                }
                return null;
            }
    
            public static Shape GetShape_UsingSetBoardMethod(string shapeName)
            {
                var assembly = Assembly.GetExecutingAssembly();
                var type = assembly.GetType(shapeName);
                var shapeObj = (Shape) Activator.CreateInstance(type);
                if (shapeObj != null)
                {
                    shapeObj.SetBoard((IBoard) Activator.CreateInstance(_configurationData[typeof (IBoard)]));
                    return shapeObj;
                }
    
                return null;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                ShapeFactory.ConfigureContainer<IBoard, ConsoleBoard>();
                var shape = ShapeFactory.GetShape_UsingSetBoardMethod("NaiveFactory.Circle");
                var shape2 = ShapeFactory.GetShape_UsingConstructorInjection("NaiveFactory.Rectangle");
                shape.Draw();
                shape2.Draw();
                Console.ReadKey();
            }
        }
    }
