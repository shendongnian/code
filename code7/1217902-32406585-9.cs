    public class TestClass : IDisposable {
        protected readonly DisposeService<TestClass> DisposeService;
        private readonly SafeHandle _handle;
        public TestClass() {
            DisposeService = new DisposeService<TestClass>(this, ps => { if (_handle != null) _handle.Dispose(); });
            _handle = new SafeFileHandle(IntPtr.Zero, true);
        }
        public void Dispose() {
            DisposeService.Dispose(true);
        }
    }
