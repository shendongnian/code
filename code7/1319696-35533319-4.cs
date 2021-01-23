    public abstract class BaseRepository
    public abstract class BaseRepository<DT>: BaseRepository, IRepository<DT>
       where DT: IDomainEntity
    public class CountryRepository: BaseRepository<Country>
  
    this.Repositories = new List<BaseRepository>();
    var o = new CountryRepository();
    this.Repositories.Add(o);
