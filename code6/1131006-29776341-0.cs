	public interface IDatabase { 
		Update(string user); 
	}
	public interface MyDatabase : IDatabase 
	{ 
		public Update(string user) {
			// update user
		}
	}
	
	public interface IService { 
		Update(string user); 
	}
	public class Service : IService 
	{
		private IDatabase _database;
		public Service(IDatabase database)
		{
			_database = database;
		}
		
		public Update(string user) {
			_database.Update(user);
		}
	}
