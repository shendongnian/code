    public abstract class B
    {
        public int Index { get; set; } // Some property that could be modified.
    }
    public class A
    {
        public class BActual : B
        {
        }
        static int nextId = -1;
        readonly B[] items; // A private read-only array that is never changed.
        public A()
        {
            items = Enumerable.Range(101 + 10 * Interlocked.Increment(ref nextId), 2).Select(i => new BActual { Index = i }).ToArray();
        }
        public string SomeProperty { get; set; }
        public IEnumerable<B> Items
        {
            get
            {
                foreach (var b in items)
                    yield return b;
            }
        }
        public string SomeOtherProperty { get; set; }
    }
    public class MidClass
    {
        public MidClass()
        {
            AnotherA = new A();
        }
        public A AnotherA { get; set; }
    }
    public class MainClass
    {
        public MainClass()
        {
            A1 = new A();
            MidClass = new MidClass();
            A2 = new A();
        }
        public List<B> ListOfB { get; set; }
        public A A2 { get; set; }
        public MidClass MidClass { get; set; }
        public A A1 { get; set; }
    }
