    public class EntityFrameworkRepository : IRepository
    {
        public T GetById<T>(object id)
        {
            return this.Set<T>().Find(id);
        }
        public IEnumerable<T> Get<T>(Expression<Func<T, bool>> criteria)
        {
            return this.Set<T>().Where(criteria);
        }
        public T Add<T>(T data)
        {
            this.Set<T>().Add(data);
            return data;
        }
    }
