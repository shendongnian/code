    public interface ICacheable<T> : ICacheable
        where T : class, new()
    {
        // All type-dependant members go here
        void CloneTo(T entity);
    }
    public interface ICacheable
    {
        // All type-agnostic members go here
    }
