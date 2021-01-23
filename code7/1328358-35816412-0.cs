    unsafe class MyClass : IDisposable
    {
        double[] parameters = new double[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private double* p;
        public double* A;
        public double* B;
        public double* C;
        GCHandle _handle;
        public MyClass()
        {
            _handle = GCHandle.Alloc(parameters, GCHandleType.Pinned);
            p = (double*)_handle.AddrOfPinnedObject().ToPointer();
            A = p;
            B = (p + 3);
            C = (p + 6);
        }
        public override string ToString()
        {
            return String.Join(", ", parameters.Select(a=>a.ToString()));
        }
        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                _handle.Free();
                disposedValue = true;
            }
        }
        ~MyClass() {
           Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
