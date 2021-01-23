    namespace ConsoleSandbox
    {
        class Program
        {
            static void Main(string[] args)
            {
                var foo = new Foo2();
                foo.OperationsOnFoo();
                foo.Foo2Methods();
                Console.ReadLine();
            }
    
        }
    
        public class Foo
        {
            public List<String> FooList { get; private set; }
    
            public Foo()
            {
                FooList = new List<string>();
            }
    
            public void OperationsOnFoo()
            {
                for (int i = 0; i < 100; i++)
                {
                    FooList.Add(i.ToString());
                }
                
            }
        }
    
        public class Foo2 : Foo
        {
            public void Foo2Methods()
            {
                Console.WriteLine(FooList.Count);
    
                foreach (var aString in FooList)
                {
                    Console.WriteLine(aString);
                }
            }
        }
    }
