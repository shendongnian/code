    public class ControllerBase {}
    public interface IDomainEntity {}
    public interface IDomainEntityModifiable {}
    public interface IDomainEntityActivatable {}
    public interface IDomainEntityNameable {}
    public interface IListRepository {}
    public interface IRepositoryRead<out TDomain> where TDomain : IDomainEntity {}
    public interface IRepositoryCreate<out TDomain> where TDomain : IDomainEntity {}
    public interface IRepositoryDelete<out TDomain> where TDomain : IDomainEntity {}
    public interface IRepositoryUpdate<out TDomain> where TDomain : IDomainEntity {}
    public class ServiceCodeController : ControllerBase 
    {
        private LazyRepo<IJobRepository, JobDomain> _domainRepo2; 
    }
    public class LazyRepo<TRepo, TDomain> where TRepo : IRepository<TDomain> where TDomain : IDomainEntity {  }
    public interface IJobRepository : IRepository<JobDomain>, IListRepository {  }
    public interface IRepository<out T> : IRepositoryRead<T>, 
        IRepositoryCreate<T>, 
        IRepositoryDelete<T>, 
        IRepositoryUpdate<T> 
        where T : IDomainEntity {  }
    public class JobDomain : BaseDomainEntity { }
    public abstract class BaseDomainEntity : IDomainEntity, 
        IDomainEntityModifiable,
        IDomainEntityActivatable, 
        IDomainEntityNameable {  }
