    public class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo(1);
            Console.WriteLine(foo.Bar);
            // This will change foo.Bar
            ChangeFoo(foo, 5); 
            Console.WriteLine(foo.Bar);
            // Does not change foo
            DoesNotChangeFoo(foo, 10);
            Console.WriteLine(foo.Bar);
            Console.Read();
        }
        static void ChangeFoo(Foo foo, int newValue)
        {
            // Since it receives a copy of the reference to Foo, it actually changes foo.Bar value
            foo.Bar = newValue;
        }
        static void DoesNotChangeFoo(Foo foo, int newValue)
        {
            // Since it receives a copy of the reference to foo, it only updates this method's reference, not changing the caller's reference
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
