    public class LayerGroup: IEnumerable
    {
    	private readonly IList<string> _collection = new List<string>();
    
    	public void Add(string value)
    	{
    		_collection.Add(value);
    	}
    
    	public IEnumerator GetEnumerator()
    	{
    		return _collection.GetEnumerator();
    	}
    }
