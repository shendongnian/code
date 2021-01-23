    public class TupleComparer : IEqualityComparer<Tuple<string, string>>
    {
    	public bool Equals(Tuple<string, string> x, Tuple<string, string> y)
    	{
    		
    		if (ReferenceEquals(x, y))
    		{
    			return true;
    		}
    		
    		if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
    		{
    			return false;
    		}
               		
    		if (x.Item1.Equals(y.Item2) && x.Item2.Equals(y.Item1))
    		{
    			return true;
    		}
    		
    		return x.Item1.Equals(y.Item1) && x.Item2.Equals(y.Item2);
    	}	
    	
    	public int GetHashCode(Tuple<string, string> tuple)
    	{
    		// implementation
    	}
    }
