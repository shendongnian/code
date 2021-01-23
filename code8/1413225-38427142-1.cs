    public class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo(1);
            Console.WriteLine(foo.Bar);
            // This will change foo's object reference
            ChangeFooObjectReference(ref foo, 15); 
            Console.WriteLine(foo.Bar);
            Console.Read();
        }
        static void ChangeFooObjectReference(ref Foo foo, int newValue)
        {
            // SInce you are receiving the actual reference used by the caller, you actually change it's own reference
            foo = new Foo(newValue);
        }
    }
    public class Foo
    {
        public Foo(int bar)
        {
            Bar = bar;
        }
        public int Bar { get; set; }
    }
