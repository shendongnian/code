    public class MyObject
    {
        public int MyNumber { get; set; } = 8;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var o = new MyObject { MyNumber = 8 };
        }
    }
