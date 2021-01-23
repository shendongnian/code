	public class GenericRepository
	{
		// ...
		
		public IQueryable<User> Include(string includeGroup = null)
		{
			return IncludeGroup(includeGroup);
		}
		
		protected virtual IncludeGroup(string includeGroup)
		{
			return _dataSet;
		}
	}
