    public class CollectionEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
    	public int GetHashCode(IEnumerable<T> obj)
    	{
    		unchecked
    		{
    			return obj.Aggregate(17, (current, item) => current * 31 + item.GetHashCode());
    		}
    	}
    
    	public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
    	{
    		return x.SequenceEqual(y);
    	}
    }
