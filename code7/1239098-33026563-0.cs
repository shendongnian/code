	void Main()
	{
		GetDashboardData().Dump();
	}
	
	public IEnumerable<string> GetUserIds()
	{
			return this.Peoples
				.Where(i => i.HasPhoto == false)
				.Select(i => i.FirstName).Distinct().ToFullyLoaded();
	}
	
	public IEnumerable<string> GetDashboardData()
	{
		var Users = this.GetUserIds();
		return Users;
	}
	
	static class Ext
	{
		public static IEnumerable<T> ToFullyLoaded<T>(this IEnumerable<T> enumerable)
		{
			return enumerable.ToList();
		}
	}
