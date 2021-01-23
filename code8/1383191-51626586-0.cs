    public abstract class BaseRepository<TEntity, TKey> : BaseRepository
       where TEntity : KeyedBaseModel<TEntity, TKey>
       where TKey : IEquatable<TKey> // I've added this line
    {
        ...
    }
