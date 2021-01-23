    public class FooSimilarityComparer:IEqualityComparer<Foo>
    {
    	public bool Equals(Foo a, Foo b)
    	{
            //called infrequently
    		return a.Bars.OrderBy(bar => bar.Id).SequenceEqual(b.Bars.OrderBy(bar => bar.Id));
    	}
    	public int GetHashCode(Foo foo)
    	{
            //called frequently
    		unchecked
    		{
    			return foo.Bars.Sum(b => b.GetHashCode());
    		}
    	}
    }
