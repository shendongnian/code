    public class Foo
    {
        private int bar;
        public int Bar
        {
            get { return bar; }
            set { }
        }
        public void CouldBeStatic()
        {
            Console.WriteLine("Hello world");
        }
        public void UsesThis(int p1, int p2, int p3, int p4, int p5)
        {
            Console.WriteLine(Bar);
            Console.WriteLine(p5);
        }
    }
    MethodBase m1 = typeof(Foo).GetMethod("CouldBeStatic");
    MethodBase m2 = typeof(Foo).GetMethod("UsesThis");
    MethodBase p1 = typeof(Foo).GetProperty("Bar").GetGetMethod();
    MethodBase p2 = typeof(Foo).GetProperty("Bar").GetSetMethod();
    bool r1 = ContainsThis(m1); // false
    bool r2 = ContainsThis(m2); // true
    bool r3 = ContainsThis(p1); // true
    bool r4 = ContainsThis(p2); // false
