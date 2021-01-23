    public class A
    {
        public int X { get; set; }
    }
    static class Extensions
    {
        public static bool IsEven(this int x)
        {
            return x%2==0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a=new A() { X=32 };
            if (a.X.IsEven())
            {
            }
        }
    }
