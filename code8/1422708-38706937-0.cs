    public interface IDbRepository
    {
        IQueryable<Holiday> GetHolidayByName(string name)
    }
    
    public class DbRepository : IDbRepository
    {
        public IQueryable<Holiday> GetHolidayByName(string name)
        {
           return db.Holiday.Where(n => string.Equals(n.Name, name));
        }
    }
    private IDbRepository _dbRepository;//initialize, preferably through construtor
    public IQueryable<Holiday> GetHolidayByName(string name)
        {
            return _dbRepository.GetHolidayByName(name)
        }
