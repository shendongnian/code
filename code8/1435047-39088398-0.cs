    void Main()
    {
    	var object2 = new DerivedClass();
    	var temp = new Allo((BaseClass)object2);
    }
    
    public class Allo
    {
    	public Allo(BaseClass value)
    	{
    		Console.WriteLine("baseclass");
    	}
    	
    	public Allo(DerivedClass value)
    	{
    		Console.WriteLine("derivedclass");
    	}
    }
    
    public class BaseClass
    {
    }
    
    public class DerivedClass : BaseClass
    {
    }
