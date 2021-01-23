    public class DisposeService<T> where T : IDisposable {
        private readonly T _disposee;
        public Action<T> ManagedAction { get; set; }
        public Action<T> UnmanagedAction { get; set; }
        public DisposeService(T disposee, Action<T> managedAction = null, Action<T> unmanagedAction = null) {
            _disposee = disposee;
            ManagedAction = managedAction;
            UnmanagedAction = unmanagedAction;
        }
        private bool _isDisposed;
        public void Dispose(bool isDisposing) {
            if (_isDisposed) return;
            if (isDisposing && ManagedAction != null) {
                ManagedAction(_disposee);
            }
            var hasUnmanagedAction = UnmanagedAction != null;
            if (hasUnmanagedAction) {
                UnmanagedAction(_disposee);
            }
            _isDisposed = true;
            if (isDisposing && hasUnmanagedAction) {
                GC.SuppressFinalize(_disposee);
            }
        }
    }
