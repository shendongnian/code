	public class StreetRepository 
	{
		private DataContext _db;
		public StreetRepository(DataContext dataContext)
		{
			_db = dataContext;
		}
	
		public Street Add(string streetName)
		{
			Street street = new Street();
			street.StreetName = streetName;
			using (var _db = new DataContext())
			{
				// Dodaj Street u bazu [AD_STREET]
				_db.DB_Street.Add(street);
				_db.SaveChanges();
			}
			// Success.
			return street;
		}
		
		public Street Get(int id)
		{
			return _db.DB_Street.Find(id);
		}
		
		// other CRUD methods
	}
