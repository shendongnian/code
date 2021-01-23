	private Data GetData(Func<KeyValuePair<Guid, IRepository>, bool> predicate = null)
	{
		var item = new Data();
		if (predicate != null)
		{
			foreach (var element in _provider.AllElements.Where(predicate))
			{
				if (element.Value is IA)
					item.ACollection.Add(MakeAItem(x.Value));
				else if (element.Value is IB)
					item.BCollection.Add(MAkeBItem(x.Value));
			}
		}
		else
		{
			item.ACollection.AddRange(_provider.AllElements.Values.Select(MakeAItem));
		}
		return item;
	}
