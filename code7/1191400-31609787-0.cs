	public abstract class Repository<T> : IRepository<T> where T : Entity, new()
	{
		protected SimpleSQLManager SQLManager = DatabaseManager.Instance.SQLManager;
		public IQueryable<T> GetAll()
		{
			IQueryable<T> all = SQLManager.Table<T>().AsQueryable();
			return all;
		}
		public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
		{
			IQueryable<T> all = SQLManager.Table<T>().Where(predicate).AsQueryable();
			
            return all;
		}
	}
	public class AirportRepository : Repository<Airport>
	{
		public IQueryable<Airport> GetByCountry(Entity country)
		{
			IQueryable<Airport> airports = GetAll( a => a.CountryId == country.Id );
			return airports;
		}
	}
