    public class TestClassDerived : TestClass, IDisposable {
        private readonly SafeHandle _derivedHandle;
        public TestClassDerived() {
            // Copy the delegate for the base's managed dispose action.
            var baseAction = DisposeService.ManagedAction;
            // Update the managed action with new disposes, while still calling the base's disposes.
            DisposeService.ManagedAction = ps => {
                if (_derivedHandle != null) {
                    _derivedHandle.Dispose();
                }
                baseAction(ps);
            };
            _derivedHandle = new SafeFileHandle(IntPtr.Zero, true);
        }
    }
