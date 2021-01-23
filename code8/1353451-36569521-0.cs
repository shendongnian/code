    public static bool ContentEquals<T>(this IEnumerable<T> enumerable, IEnumerable<T> other)
    	{
    		if (Equals(enumerable, other))
    		{
    			return true;
    		}
    
    		if (enumerable == null || other == null)
    		{
    			return false;
    		}
    
    		if (enumerable.Count() != other.Count() || enumerable.Except(other).Any())
    		{
    			return false;
    		}
    
    		foreach (T value in enumerable.Distinct())
    		{
    			if (enumerable.Count(v => Equals(v, value)) != other.Count(v => Equals(v, value)))
    			{
    				return false;
    			}
    		}
    
    		return true;
    	}
