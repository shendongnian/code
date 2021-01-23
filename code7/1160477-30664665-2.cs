    public sealed class DisposableLazy<T> : Lazy<T>, IDisposable where T : IDisposable
    {
        public DisposableLazy(Func<T> valueFactory) : base(valueFactory)
        {
        }
        // No unmanaged resources in this class, and it is sealed.
        // No finalizer needed.
        public void Dispose()
        {
            if (IsValueCreated)
            {
                Value.Dispose();
            }
        }
    }
