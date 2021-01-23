    public interface IClassAORClassB {}
    class A : IClassAORClassB { }
    class B : IClassAORClassB { }
    public static class Captions
    {
        public static string Caption<T>(this T obj) where T : IClassAORClassB
        {
            return typeof(T).ToString();
        }
    }
    static void Main(string[] args)
    {
        var a = new A();
        var b = new B();
        var all = new IClassAORClassB[] { a, b }; // works just fine
        Console.WriteLine(a.Caption());
        Console.WriteLine(b.Caption());
    }
