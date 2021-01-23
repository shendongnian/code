    public class MyObject
    {
        public MyObject()
        {
            MyNumber = 6;
        }
        public int MyNumber { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var o = new MyObject { MyNumber = 8 };
        }
    }
