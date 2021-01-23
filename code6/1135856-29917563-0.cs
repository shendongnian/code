    void Main()
    {
    	var flags = Ext.GetFlags<Animal>(7);
    	flags.Dump();
    }
    
    public static class Ext
    {
    	public static IEnumerable<T> GetFlags<T>(int flags)
    	where T : struct
    		
    	{
    		return typeof(T).GetEnumValues().Cast<T>()
    			.Where(a => ((dynamic)(T)(object)flags).HasFlag(a)).ToList();
    	}
    }
    
    [Flags]
    public enum Animal
    {
    	Cow =1,
    	Duck = 2,
    	Goose = 4,
    	Dog = 8
    }
    // Define other methods and classes here
