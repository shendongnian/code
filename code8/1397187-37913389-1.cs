    void Main()
    {
    	var myDict = new MyWrappedDictionary();
    	myDict.Add(() => "Rob");
    	var func = myDict.Get<string>();
    	Console.WriteLine(func());
    }
    
    public class MyWrappedDictionary
    {
    	private Dictionary<Type, object> innerDictionary = new Dictionary<Type, object>();
    	public void Add<T>(Func<T> func)
    	{
    		innerDictionary.Add(typeof(T), func);
    	}
    	public Func<T> Get<T>()
    	{
    		return innerDictionary[typeof(T)] as Func<T>;
    	}
    }
