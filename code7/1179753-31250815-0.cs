	public IReadOnlyDictionary<string, object> this[int i] 
	{
		get { return this._list[i]; }
	}
	//OR
	public IReadOnlyDictionary<string, object> GetListItem(int i)
	{
		return _list[i];
	}
	public int ListCount
	{
		get { return this._list.Count; }
	}  
