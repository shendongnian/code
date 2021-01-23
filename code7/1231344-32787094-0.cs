    public interface IEntityService
    {
        void DoSomething(object item);
    }
    public interface IEntityService<T> : IEntityService
    {
        void DoSomething(T item);
    }
