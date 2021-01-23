    void Main()
    {
    	var a = A.GetInstance();
    	var b = A<object>.GetInstance();
    	Console.WriteLine(a);
    	Console.WriteLine(b);
    }
    
    class A<T>
    {
    	public static A<T> GetInstance()
    	{
    		return new A<T>();
    	}
    }
    
    class A : A<object>
    {
    }
