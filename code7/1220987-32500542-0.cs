    public class MyClass
    {
    	private readonly MyDependency _dependency;
    
    	public MyClass()
    	{
    		_dependency.MyMethod();
    	}
    
    	public bool IsDependencyNull()
    	{
    		return _dependency == null;
    	}
    }
    
    public class MyDependency { public void MyMethod() { } } 
