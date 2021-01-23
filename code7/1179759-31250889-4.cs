    public ReadOnlyCollection<ReadOnlyDictionary<string, object>> AsReadOnlyListAndElements
    {
    	get
    	{
    		var list = _list.Select(elem => new ReadOnlyDictionary<string, object>(elem));
    		return list.ToList().AsReadOnly();
    	}
    }
