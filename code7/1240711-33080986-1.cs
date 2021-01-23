	public class Constructor
	{
		private volatile Dictionary<int, string> _contactIdNames;
	
		public Constructor()
		{
			Observable
				.Interval(TimeSpan.FromSeconds(10.0))
				.StartWith(-1)
				.Select(n =>
				{
					using (var db = new DBEntities())
					{
						return db.ContactIDs.ToDictionary(
							x => x.Qualifier * 1000 + x.AlarmCode,
							x => x.Description);
					}
				})
				.Subscribe(x => _contactIdNames = x);
		}
		
		public string TryGetValue(int key)
		{
			string value = null;
			_contactIdNames.TryGetValue(key, out value);
			return value;
		}
	}
