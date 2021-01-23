	public Data GetData(DataSettings settings)
	{
		return GetData(x => settings.RepositoryIds.Contains(x.Key));
	}
	
	private Data GetData(Func<KeyValuePair<Guid, IRepository>, bool> predicate = null)
	{
		var item = new Data();
		
		foreach (KeyValuePair<Guid, IRepository> kvp in _provider.AllElements) 
		{
			if (predicate != null)
			{
				if (predicate(kvp)) 
				{
					IA aValue = kvp.Value as IA;
					if (aValue != null) 
					{
						item.ACollection.Add(MakeAItem(aValue)); // uses: AItem MakeAItem(IA a);
					}
					
					IB bValue = kvp.Value as IB;
					if (bValue != null) 
					{
						item.BCollection.Add(MakeBItem(bValue));
					}
				}
			}
			else
			{
				item.ACollection.Add(MakeAItem(kvp.Value)); // uses: AItem MakeAItem(IRepository repo);
			}
		}
		
		return item;
	}
