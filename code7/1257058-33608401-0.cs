    public static class Util
    {
    	public static IEnumerable<string> GetSynonims(this Enum value)
    	{
    		Type e = value.GetType();	
    		
    		return Enum.GetNames(e).Where(n => Enum.Parse(e, n).Equals(value));
    	}
    }
