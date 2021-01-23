    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IDataRepository DataRepository { get; }
        void Commit();
    }
