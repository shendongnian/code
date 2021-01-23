    public static class Grouping
    {
    	public static Grouping<TKey, TElement> Create<TKey, TElement>(TKey key, IEnumerable<TElement> elements)
    	{
    		return new Grouping<TKey, TElement> { Key = key, Elements = elements };
    	}
    }
