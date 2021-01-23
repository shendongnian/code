    public static class StructExtensions
    {
    	public static TProperty GetOrDefault<TObject, TProperty>(this TObject someObject, Func<TObject, TProperty> propertySelectionFunc)
    		where TObject : class 
    		where TProperty : struct
    	{
    		Contract.Requires(propertySelectionFunc != null);
    		
    		return someObject == null ? default(TProperty) : propertySelectionFunc(someObject);
    	}
    }
