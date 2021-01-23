    class A
    {
        private readonly int bar;
        public A()
        {
            bar = 1;
        }
        public void Foo()
        {
            Console.WriteLine(bar);
        }
    }
    var a = new A();
    a.Foo(); // displays "1"
    a.GetType().GetField("bar", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(a, 2);
    a.Foo(); // displays "2"
