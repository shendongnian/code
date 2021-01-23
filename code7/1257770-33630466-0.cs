    public class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
    	private IEnumerable<TElement> collection;
    	public Grouping(TKey key, IEnumerable<TElement> collection)
    	{
    		Key = key;
    		this.collection = collection;
    	}
        public TKey Key
        {
            get;
            set;
        }
    
    	public IEnumerator<TElement> GetEnumerator()
    	{
    		return collection.GetEnumerator();
    	}
    	
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return GetEnumerator();
    	}
    }
