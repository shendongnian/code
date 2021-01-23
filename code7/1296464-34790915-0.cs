	public class UserRepository
	{
		private readonly IQueryable<User> _dataSet;
		
		public UserRepository(IQueryable<User> userDataSet)
		{
			_dataSet = userDataSet;
		}
		
		public IQueryable<User> Include()
		{
			return _dataSet.Include(u => u.Book)
						   .Include(u => u.Blog);
		}
	}
	
