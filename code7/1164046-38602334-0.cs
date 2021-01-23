    public interface IDataResult<T>
    {
        IDataResult<T> FilterBy(Expression<Func<T, bool>> predicate);
        IDataResult<TResult> ProjectTo<TResult>(Expression<Func<T, TResult>> predicate);
        IDataResult<T> SortBy<TKey>(Expression<Func<T, TKey>> keySelector);
        IDataResult<T> SortByDescending<TKey>(Expression<Func<T, TKey>> keySelector);
        List<T> ToList();
        IEnumerable<T> AsEnumerable();
    }
    public class DataResult<T> : IDataResult<T>
    {
        private IQueryable<T> Query { get; set; }
        
        public DataResult(IQueryable<T> originalQuery)
        {
            this.Query = originalQuery;
        }
        
        public IDataResult<T> FilterBy(Expression<Func<T, bool>> predicate)
        {
            this.Query = this.Query.Where(predicate);
            return this;
        }
        public IDataResult<T> SortBy<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            this.Query = this.Query.OrderBy(keySelector);
            return this;
        }
        public IDataResult<T> SortByDescending<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            this.Query = this.Query.OrderByDescending(keySelector);
            return this;
        }
        public IDataResult<TResult> ProjectTo<TResult>(Expression<Func<T, TResult>> predicate)
        {
            return new DataResult<TResult>(this.Query.Select(predicate));
        }
        public List<T> ToList()
        {
            return this.Query.ToList();
        }
        public IEnumerable<T> AsEnumerable()
        {
            return this.Query.AsEnumerable();
        }
    } 
