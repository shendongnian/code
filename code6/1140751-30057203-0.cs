    public class Foo
    {
        public Foo(ILog log)
        { 
            Console.WriteLine(log.Logger.Name);
        }
    }
    public class Bar
    {
        public Bar(ILog log)
        { 
            Console.WriteLine(log.Logger.Name);
        }
    }
