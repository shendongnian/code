    class ClassA : IDisposable
    {
        private ClassB b;
        public ClassA (ClassB b) { this.b = b; }
        public void Dispose() { this.b.Dispose(); }
    }
