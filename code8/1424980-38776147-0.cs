    public class ColumnEqualityComparer : EqualityComparer<IEnumerable<string>>
    {
    	public static readonly ColumnEqualityComparer Instance = new ColumnEqualityComparer();
    	private ColumnEqualityComparer() { }
    	public override int GetHashCode(IEnumerable<string> obj)
    	{
    		if (obj == null) return 0;
    		// You can implement better hash function
    		int hashCode = 0;
    		foreach (var item in obj)
    			hashCode ^= item != null ? item.GetHashCode() : 0;
    		return hashCode;
    	}
    	public override bool Equals(IEnumerable<string> x, IEnumerable<string> y)
    	{
    		if (x == y) return true;
    		if (x == null || y == null) return false;
    		return x.SequenceEqual(y);
    	}
    }
