    public abstract class A<T>
    {
        public static Dictionary<Type, int> TempIDs = new Dictionary<Type, int>();
        public int ID { get; set; }
        public A()
        {
            if (!TempIDs.ContainsKey(typeof(T)))
                TempIDs.Add(typeof(T), 0);
            this.ID = TempIDs[typeof(T)] - 1;
            TempIDs[typeof(T)]--;
        }
    }
    public class B : A<B>
    {
        public string Foo { get; set; }
        public B(string foo)
            : base()
        {
            this.Foo = foo;
        }
    }
    public class C : A<C>
    {
        public string Bar { get; set; }
        public C(string bar)
            : base()
        {
            this.Bar = bar;
        }
    }
    B b1 = new B("foo");
    B b2 = new B("bar");
    C c1 = new C("foo");
    C c2 = new C("foo");
