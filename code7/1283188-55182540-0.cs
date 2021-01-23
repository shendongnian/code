    public class SimpleLazy<T> where T : class
    {
        private readonly Func<T> valueFactory;
        private T instance;
        public SimpleLazy(Func<T> valueFactory)
        {
            this.valueFactory = valueFactory;
            this.instance = null;
        }
        public T Value
        {
            get
            {
                return LazyInitializer.EnsureInitialized(ref instance, valueFactory);
            }
        }
    }
