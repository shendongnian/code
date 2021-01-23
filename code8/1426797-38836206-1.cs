    public class A
    {
        public static void Foo()
        {
            Console.WriteLine(B.bar == null);
        }
    }
    public class B
    {
        public static readonly object bar = Foo();
        public static object Foo()
        {
            A.Foo();
            return 5;
        }
    }
    private static void Main(string[] args)
    {
        var bar = B.bar;
    }
