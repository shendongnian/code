    public class EnumerableWrapper<T> : IDisposableEnumerable<T>
    {
        private readonly IEnumerable<T> m_Enumerable;
        public EnumerableWrapper(IEnumerable<T> enumerable)
        {
            m_Enumerable = enumerable;
        }
        public void Dispose()
        {
        }
        public IEnumerator<T> GetEnumerator()
        {
            return m_Enumerable.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) m_Enumerable).GetEnumerator();
        }
    }
    public class CompositeDisposableEnumerable<T> : IDisposableEnumerable<T>
    {
        private readonly IDisposableEnumerable<T>[] m_DisposableEnumerables;
        public CompositeDisposableEnumerable(params IDisposableEnumerable<T>[] disposable_enumerables)
        {
            m_DisposableEnumerables = disposable_enumerables;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var disposable_enumerable in m_DisposableEnumerables)
            {
                foreach (var item in disposable_enumerable)
                    yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Dispose()
        {
            foreach (var disposable_enumerable in m_DisposableEnumerables)
                disposable_enumerable.Dispose();
        }
    }
