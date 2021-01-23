    public class ExceptionCollection : IEnumerable<Type>
    {
        private readonly List<Type> _exceptions = new List<Type>();        
        
        public void Add<T>() where T : Exception => _exceptions.Add(typeof(T));
        public IEnumerator<Type> GetEnumerator() => _exceptions.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_exceptions).GetEnumerator();
    }
