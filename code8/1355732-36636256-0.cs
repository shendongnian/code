    public interface IUnitOfWork : IDisposable {
        ... repositories 
        IMyEntityRepository MyEntityRepository;
        ...
    }
