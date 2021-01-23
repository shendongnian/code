    abstract class A<T> where T:new()
    {
    	public static T GetInstance()
    	{
    		return new T();
    	}
    }
    
    class A : A<A>
    {
    }
