    class Program
    {
        static void Main(string[] args)
        {
            object obj = new Foo();
            Type objType = obj.GetType();
            
            if(objType == typeof(Foo))
            {
                var foobar = (Foo)obj;
                Console.WriteLine(foobar.Bar);
            }
            else if(objType == typeof(int))
            {
                // Do something
            }
            else
            {
                // Do something
            }
            // If you are brave enough you can use dynamic
            dynamic bar = obj;
            Console.WriteLine(bar.Bar);
                       
            Console.ReadLine();
        }
    }
    class Foo
    {
        public string Bar { get; set; }
        public Foo()
        {
            Bar = "FooBar";
        }
    }
