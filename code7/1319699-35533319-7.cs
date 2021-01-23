    public interface IRepository<out DT> where DT: IDomainEntity
    public abstract class BaseRepository<DT> : IRepository<DT>
      where DT : IDomainEntity
  
    public class CountryRepository : BaseRepository<Country>
   
    // Note the usage of IRepository<IDomainEntity>, not BaseRepository 
    this.Repositories = new List<IRepository<IDomainEntity>>();   
    var o = new CountryRepository();
    this.Repositories.Add(o);
 
