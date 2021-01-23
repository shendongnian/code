    public class FakeDbSet<T> : IDbSet<T> where T : class
    {
        private Func<T, object[], bool> _findSelector
        private readonly HashSet<T> data;
        private readonly IQueryable query;
    
        public FakeDbSet(Func<T, object[], bool> findSelector)
        {
            _findSelector = findSelector;
            data = new HashSet<T>();
            query = data.AsQueryable();
        }
    
        public virtual T Find(params object[] keyValues)
        {
            return _data.SingleOrDefault(item => _findSelector(item, keyValues));
        }
    }
