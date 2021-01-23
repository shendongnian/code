	public virtual List<T> GetCache<T>()
	{
		List<T> list = new List<T>();
		IDictionaryEnumerator cacheEnumerator = (IDictionaryEnumerator)((IEnumerable)Cache).GetEnumerator();
		while (cacheEnumerator.MoveNext())
		    list.Add((T) cacheEnumerator.Value);
		return list;
	}
