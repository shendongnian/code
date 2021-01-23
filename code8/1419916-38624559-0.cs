    public class CaseInsensitiveIndex
    {
    	private readonly Dictionary<string, object> _collection = 
            new Dictionary<string, object>();
    	
    	public object this[string index]
        {
    		get { return _collection[index.ToLower()]; }
    		set { _collection[index.ToLower()] = value; }
    	}
    }
    public interface IHasCaseInsensitiveIndex
    {
        CaseInsensitiveIndex Index { get; }
    }
