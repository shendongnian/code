    public interface IRepository<T, TKey>
        where T : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
      ...
      Get<T>(TKey key)
    }
