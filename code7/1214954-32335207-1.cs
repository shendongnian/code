    public interface IUnitOfWork
    {
        TRepository GetRepository<TRepository>() where TRepository: IRepository;
        void Commit();
    }
