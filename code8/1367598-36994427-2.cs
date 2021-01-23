    class Program
    {
        static void Main(string[] args)
        {
            int i = FooBar(new Foo());
            Console.WriteLine(i);
            Console.ReadLine();
        }
        public static int FooBar(FooBase fooBase)
        {
            int val = -1;
            Type type = fooBase.GetType();
            if(type == typeof(Foo))
            {
                Foo foo = (Foo)fooBase;
                val = foo.Bar;
            }
            else
            {
                // Do something
            }
            return val;
        }
    }
    class Foo : FooBase
    {
        public int Bar { get; set; }
        public Foo()
        {
            Bar = 999;
        }
    }
    class FooBase
    {
    }
