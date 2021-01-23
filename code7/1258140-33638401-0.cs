    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(typeof(StaticClass).Attributes);
    		Console.WriteLine(typeof(NotStaticClass).Attributes);
    	}
    }
    
    public static class StaticClass { }
    
    public class NotStaticClass { }
