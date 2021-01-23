	private object _gate = new object();
	List<item> GetItems(int AccountID)
	{
		lock (_gate)
		{
			var x = getFromCache(AccountID);
			if (x == null)
			{
				x = new Lazy<List<item>>(() => getFromDatabase(AccountID));
				addToCache(AccountID, x);
			}
			return x.Value;
		}
	}
	
