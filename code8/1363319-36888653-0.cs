     public class C
    {
        private readonly IA a;
        private readonly IB b;
        public C(IA a, IB b)
        {
            this.a = a;
            this.b = b;
        }
        public void Dosomething()
        {
            // do something with this.a or this.b.
        }
    }
