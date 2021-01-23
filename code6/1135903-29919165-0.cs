	public Data GetData(DataSettings settings)
	{
		return GetData(settings.RepositoryIds);
	}
	private Data GetData(IEnumerable<Guid> keys)
	{
		var item = new Data();
		
		foreach(var key in keys)
		{
			IRepository value = null;
			if(_provider.AllElements.TryGetValue(key, out value))
			{
				if(value is IA)
					data.ACollection.Add(value);
				if(value is IB)
					data.BCollection.Add(value);
			}
		}
		
		return item;
	}
