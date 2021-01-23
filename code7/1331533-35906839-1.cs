    class MyComparer : IEqualityComparer<Foo>
    {
    	public bool Equals(Foo left, Foo right)
    	{
    		return left.Bars.Count() == right.Bars.Count() && //have the same amount of bars
    			left.Bars.Select(x => x.Id)
    			.Except(right.Bars.Select(y => y.Id))
    			.ToList().Count == 0; //and when excepted returns 0, mean similar bar
    	}
    	
    	public int GetHashCode(Foo foo)
    	{
    		unchecked {
    			int hc = 0;
    			if (foo.Bars != null)
    				foreach (var p in foo.Bars)
    				hc ^= p.GetHashCode();
    			return hc;
    		}
    	}
    }
