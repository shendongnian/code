    class A
    {
        public B PropA { get; set; }
    }
    class B
    {
        public string PropB { get; set; }
        public C PropC { get; set; }
    }
    class C
    {
        public string PropD { get; set; }
    }
    class Program
    {
        static object GetPValue(Type propType, object obj)
        {
            return obj.GetType().GetProperties()
                .First(p => p.PropertyType == propType).GetValue(obj);
        }
        static object GetPValue(string name, object obj)
        {
            return obj.GetType().GetProperty(name).GetValue(obj);
        }
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();
            a.PropA = b;
            b.PropB = "B";
            b.PropC = c;
            c.PropD = "C";
            object obj = new object();
            obj = GetPValue(typeof(C), GetPValue(typeof(B), a));
            Console.WriteLine(GetPValue("PropD", obj));
        }
    }
