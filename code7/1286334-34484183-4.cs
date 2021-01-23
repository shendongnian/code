    public static class StructExtensions
    {
        // Check that TProperty is nullable for the return value (this is how C#6's
        // null-conditional operator works with value types
    	public static TProperty? GetOrDefault<TObject, TProperty>(this TObject someObject, Func<TObject, TProperty> propertySelectionFunc)
    		where TObject : class 
    		where TProperty : struct
    	{
    		Contract.Requires(propertySelectionFunc != null);
    		
    		return someObject == null ? default(TProperty?) : propertySelectionFunc(someObject);
    	}
    }
