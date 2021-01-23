    public interface IClassAORClassB {}
    class A : IClassAORClassB { }
    class B : IClassAORClassB { }
    public static class Captions
    {
        public static string Caption<T>(this T obj) where T : IClassAORClassB
        {
            return obj.GetType().ToString();
        }
    }
    static void Main(string[] args)
    {
        var a = new A();
        var b = new B();
        var all = new IClassAORClassB[] { a, b }; // works just fine
        Console.WriteLine(all[0].Caption()); // prints A
        Console.WriteLine(all[1].Caption()); // prints B
    }
