    public class AggregatedResult<T>
    {
    	private readonly T _value;
    	
    	public AggregatedResult(T value)
    	{
    		this._value = value;
    	}
    	
    	pulbic T Value
    	{
    		get
    		{
    			return this._value;
    		}
    	}
    	
    	public static implicit operator T(AggregatedResult<T> item)
    	{
    		if (item == null)
    			throw new ArgumentNullException(paramName: nameof(item));
    			
    		return item.Value;
    	}
    }
    
    
    public class MyAggregatedResult : AggegatedResult<Int32>
    {	
    	public MyAggregatedResult(Int32 value) : : base(value)
    	{
    		
    	}
    	
    	public MyAggregatedResult WithInner(int a) { /*do something*/ return new MyAggregatedResult(this.Value + 1); }
    	public MyAggregatedResult WithInner(string a) { /*do something*/ return new MyAggregatedResult(this.Value + 2); }
    	public MyAggregatedResult WithInner(string[] a) { /*do something*/ return new MyAggregatedResult(this.Value + 3);}
    }
...
    var value = new MyAggregatedResult(100);
    Console.WriteLine(value.WithInner("").WithInner(new String[0]).Value);
