	public class TEqualityComparer<V> : IEqualityComparer<T<V>>
	{
	    public bool Equals(T<V> t1, T<V> t2)
	    {
	        if (t2 == null && t1 == null)
	            return true;
	        else if (t1 == null || t2 == null)
	            return false;
	        else
	        {
	            return
	                t1.X.Select(x => x.A).SequenceEqual(t2.X.Select(x => x.A))
	                && t1.X.Select(x => x.B).SequenceEqual(t2.X.Select(x => x.B));
	        }
	    }
	
	    public int GetHashCode(T<V> t)
	    {
	        return t.X.Select(x => x.A.GetHashCode())
	            .Concat(t.X.Select(x => x.B.GetHashCode()))
	            .Aggregate((x1, x2) => (x1 * 17 + 13) ^ x2);
	    }
	}
