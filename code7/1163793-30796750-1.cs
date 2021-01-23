    public class BaseClass
    {
        public void Call()
        {
            if (this is DerivedClass<int>)
            {
                CallInt();
            }
            else if (this is DerivedClass<string>)
            {
                CallString();
            }
            else
            {
                Console.WriteLine("Base class");
            }
        }
    	
    	public void CallInt()
    	{
    		Console.WriteLine("It's an int");
    	}
    	
    	public void CallString()
    	{
    		Console.WriteLine("It's a string");
    	}
    }
    
    public class DerivedClass<T> : BaseClass {
    	
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		var intClass = new DerivedClass<int>();
    		var stringClass = new DerivedClass<string>();
    		intClass.Call(); // writes 'It's an int'
    		stringClass.Call(); // writes 'It's a string'
    	}
    }
