    class XXEqualityComparer : IEqualityComparer<XX>
    {
    	public static readonly XXEqualityComparer Instance = new XXEqualityComparer();
    	
    	private XXEqualityComparer()
    	{
    	}
    
    	public bool Equals(XX x, XX y)
    	{
    		if (ReferenceEquals(x, y))
    			return true;
    			
    		if (x == null || y == null)
    			return false;
    			
    		return x.t1 == y.t1
    			&& x.t2 == y.t2;
    	}
    	
    	public int GetHashCode(XX obj)
    	{
    		return obj == null ? 0 : obj.t1 ^ (397 * obj.t2.GetHashCode());
    	}
    }
