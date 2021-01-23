	public interface IDatabase { 
		Update(User user); 
	}
	public interface MyDatabase : IDatabase 
	{ 
		public Update(User user) {
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
		
		public Update(User user) {
			_database.Update(user);
		}
	}
