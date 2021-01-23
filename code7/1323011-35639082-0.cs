    public class T2
    {
	    public string Name;
	}
	public class T
	{
		public IEnumerable<T2> childT2Collection;
		public IEnumerable<T> childTCollection;
	}
	public IEnumerable<T2> childs(T t, string searchValue)
	{
		if (t.childT2Collection.Any(e => e.Name == searchValue))
			return t.childT2Collection;
		return t.childTCollection.SelectMany(e=>childs(e, searchValue));
	}
	T2 Find(IEnumerable<T> primaryCollection, string searchValue)
	{
		return primaryCollection.SelectMany(t => childs(t,searchValue)).FirstOrDefault(e => e.Name == searchValue);
	}
