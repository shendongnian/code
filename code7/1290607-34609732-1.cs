    public class Maybe<T>
    {
    	public readonly static Maybe<T> Nothing = new Maybe<T>();
    
    	public T Value { get; private set; }
    	public bool HasValue { get; private set; }
    
    	public Maybe()
    	{
    		HasValue = false;
    	}
    
    	public Maybe(T value)
    	{
    		Value = value;
    		HasValue = true;
    	}
    
    	public static implicit operator Maybe<T>(T v)
    	{
    		return v.ToMaybe();
    	}
    }
