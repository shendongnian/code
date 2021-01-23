    public class Id<I, O> : IInterface<I, O>
    {
        private Func<I, O> f;
        public Id(Func<I, O> f) { this.f = f; }
        public IInterface<I, O> DoSomething(I i) { this.f(i); return this; }
        public IInterface<I, O> DoSomethingWithFunc(Func<I, O> newF) {
            this.f = newF;
            return this;
        }
    }
