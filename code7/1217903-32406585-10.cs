    public class TestClass : IDisposable {
        protected readonly DisposeService<TestClass> DisposeService;
        private readonly SafeHandle _handle;
        public TestClass() {
            DisposeService = new DisposeService<TestClass>(this,
                ps => { if (_handle != null) _handle.Dispose(); },
                ps => { /* Free unmanaged resources here */ });
            _handle = new SafeFileHandle(IntPtr.Zero, true);
        }
        public void Dispose() {
            DisposeService.Dispose(true);
        }
        ~TestClass() {
            DisposeService.Dispose(false);
        }
    }
