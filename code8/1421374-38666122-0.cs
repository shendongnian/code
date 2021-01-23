    public class Program
    {
        public static void Main(string[] args)
        {
            var foo1 = new Foo() { Bar = 1 };
            var foo2 = new Foo() { Bar = 2 };
            AddOne(foo1, foo2);
        }
        public static void AddOne(params Foo[] foos)
        {
            foreach(var foo in foos)
            {
                foo.Bar++;
            }
        }
        public class Foo
        {
            public int Bar { get; set; }
        }
    }
