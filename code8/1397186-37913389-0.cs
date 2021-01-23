    void Main()
    {
    	var myDict = new MyWrappedDictionary();
    	myDict.Add(() => "Rob");
    	var func = myDict.Get<string>();
    	Console.WriteLine(func());
    }
    
    public class MyWrappedDictionary
    {
    	private Dictionary<Type, Func<object>> innerDictionary = new Dictionary<Type, Func<object>>();
    	public void Add<T>(Func<T> func)
    		where T : class
    	{
    		innerDictionary.Add(typeof(T), func);
    	}
    	public Func<T> Get<T>()
    		where T : class
    	{
    		return innerDictionary[typeof(T)] as Func<T>;
    	}
    }
