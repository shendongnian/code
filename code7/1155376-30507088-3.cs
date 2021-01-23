    public class ExampleRoot : ObjectWithReferences
    {
        public ExampleRoot() : base(null)
        {
        }
        public void Foo()
        {
            if (IsDisposed)
            {
                return;
            }
            // Do Foo things
        }
        public void CreateChild()
        {
            if (IsDisposed)
            {
                return;
            }
            // Auto-adds itself!
            var child = new ExampleChild(this);
        }
    }
    public class ExampleChild : ObjectWithReferences
    {
        private byte[] BigBuffer = new byte[1000000];
        public ExampleChild(ExampleRoot parent) : base(parent)
        {
        }
        protected override void Dispose(bool disposing)
        {
            // The ExampleChild object has a very long possible lifetime,
            // because it will live even in the IsDisposed == true state,
            // so it is better to free even managed resources.
            BigBuffer = null;
        }
    }
