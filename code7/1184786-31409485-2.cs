    class WrapC : IDisposable {
        private readonly B b;
        public C C { get; private set; }
        public WrapC (B b) {
            this.b = b;
            C = new C(b);
        }
        public void Dispose() {
            b.Dispose();
        }
    }
