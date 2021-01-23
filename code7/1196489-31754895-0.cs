    class Program
    {
    	static void Main(string[] args)
    	{
    		new WithoutGeneric().GoExecute();
    		new WithGeneric<string>().GoExecute();
    	}
    }
    
    public class WithoutGeneric
    {
    	public void GoExecute()
    	{
    		//Works fine
    		StaticMethods.PrepareThisFunc1(() => "Test");
    	}
    }
    
    public class WithGeneric<T>
    {
    	public void GoExecute()
    	{
    		//Works fine
    		StaticMethods.PrepareThisFunc2(() => "Test");
    	}
    }
    
    public static class StaticMethods
    {
    	public static void PrepareThisFunc1(Func<string> theFunc)
    	{
    		RuntimeHelpers.PrepareMethod(theFunc.Method.MethodHandle);
    	}
    
    	public static void PrepareThisFunc2(Func<string> theFunc)
    	{
    		RuntimeHelpers.PrepareMethod(theFunc.Method.MethodHandle, new[] { typeof(string).TypeHandle });
    	}
    }
