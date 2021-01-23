    public interface ITransaction
    {
    }
    public interface IVolatileTransaction<T> : ITransaction where T : ITransaction
    {
    }
