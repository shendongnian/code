    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo();
            SetNull(foo);
    
            Console.WriteLine(foo.ID);// print 2
        }
    
        private static void SetNull(Foo foo)
        {
            foo.ID = 2;
            foo = null;
        }
    }
    
    
    class Foo
    {
        public int ID { get; set; }
    }
