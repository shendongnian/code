    public sealed class ABuilder
    {
        public int X { get; set; }
        public ABuilder(A a)
        {
            this.X = a.X;
        }
        public A Build()
        {
            return new A(X);
        }
    }
