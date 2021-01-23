    public static partial class MyEnumExtensions
    {
    	public static MyEnumHolder<T> ToHolder<T>(this T source)
    		where T : struct, IConvertible
    	{
    		return new MyEnumHolder<T>(source);
    	}
    }
    
    public class MyEnumHolder<T> where T : struct, IConvertible
    {
    	static readonly Func<T, string> toStringFunc;
    	static readonly Func<string, T> toEnumFunc;
    	static MyEnumHolder()
    	{
    		if (!typeof(T).IsEnum) throw new NotSupportedException();
    		// Use your naming conventions
    		var name = typeof(T).Name;
    		toStringFunc = (Func<T, string>)Delegate.CreateDelegate(typeof(Func<T, string>),
    			typeof(MyEnumExtensions).GetMethod("toString", new[] { typeof(T) }));
    		toEnumFunc = (Func<string, T>)Delegate.CreateDelegate(typeof(Func<string, T>),
    			typeof(MyEnumExtensions).GetMethod("to" + name, new[] { typeof(string) }));
    	}
    
    	private T value;
    	public MyEnumHolder() { value = default(T); }
    	public MyEnumHolder(T value) { this.value = value; }
    	static public implicit operator MyEnumHolder<T>(T x) { return new MyEnumHolder<T>(x); }
    	static public implicit operator T(MyEnumHolder<T> x) { return x.value; }
    	public string toString()
    	{
    		return toStringFunc(value);
    	}
    	public void fromString(string xString)
    	{
    		value = toEnumFunc(xString);
    	}
    }
