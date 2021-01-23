    public class Foo<T> where T : new()
    {
        public T Bar { get; } = new T();
        public void FooMethod() => Console.WriteLine("Foo method");
    }
    public class A
    {
        public void AMethod() => Console.WriteLine("A method");
    }
    public class X : Foo<A>
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            var x = new X();
            x.FooMethod();
            x.Bar.AMethod(); // access via property
        }
    }
