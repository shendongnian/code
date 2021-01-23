    public class Repository
    {
        public T Get<T, TId>(TId id) where T: IEntity<TId>
        {
            // fake implementation, but T is required at compile time
            var result = Activator.CreateInstance<T>();
            result.Id = id;
            return result;
        }
        public GetHelper<T> Get<T>()
        {
            return new GetHelper<T>(this);
        }
    }
