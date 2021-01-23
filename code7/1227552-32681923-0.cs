    class test<T>
    {
    	public T Return()
    	{
    		return default(T);
    	}
    }
    
    void Main()
    {
    	Console.WriteLine ((new test<string>()).Return());
    	Console.WriteLine ((new test<int>()).Return());
    	Console.WriteLine ((new test<Stream>()).Return());
    }
