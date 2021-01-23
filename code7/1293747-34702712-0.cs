    public class IDCollection : IEnumerable<KeyValuePair<string, ID>>
    {
    	private IDictionary<string, ID> List = new Dictionary<string, ID>();
    
    	public IEnumerator<KeyValuePair<string, ID>> GetEnumerator()
    	{
    		return List.GetEnumerator();
    	}
    
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return this.GetEnumerator();
    	}
    }
