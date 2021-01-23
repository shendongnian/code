    public class Repository<T, TKey> : IRepository<T, TKey>
            where T : IEntity<TKey>
            where TKey : IEquatable<TKey>
    {
    ...
        public virtual Get<T>(TKey key)
        {
            var session = ... // get current session
            var result = session.Get<T>(key);
            return result;
        }
    }
