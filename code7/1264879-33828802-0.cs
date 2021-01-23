    public class DelegateExample
    {
        public delegate void MyDelegate();
        public void PrintMessage(MyDelegate d)
        {
            d();
        }
        public void PrintHello()
        {
            Console.WriteLine("Hello.");
        }
        public void PrintWorld()
        {
            Console.WriteLine("World.");
        }
        public static void Main(string[] args)
        {
            PrintDelegate(new MyDelegate(PrintHello));
            PrintDelegate(new MyDelegate(PrintWorld));
        }
    }
