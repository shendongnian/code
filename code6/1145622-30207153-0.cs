    using System;
    using System.Linq;
    using System.Reflection;
    
    public class Program
    {
    	public static void Main()
    	{
    		Program p = new Program();
    		Type[] types = Assembly.GetExecutingAssembly().GetTypes();
    		Type TEnum = types.Where(d => d.Name == "TEnum").FirstOrDefault();
    		var values = TEnum.GetEnumValues();
    		var error = new object ();
    		foreach (var value in values)
    		{
    			if (value.ToString() == "Test2")
    			{
    				error = value;
    			}
    		}
    
    		var program = Assembly.GetExecutingAssembly().GetTypes().First(d => d.Name == "Program");
    		foreach (var method in program.GetMethods())
    		{
    			if (method.Name == "TestMethod")
    			{
    				method.Invoke(null, new object[2] // may need to pass instance in case of instance method.
    				{
    				"A", error
    				}
    
    				);
    			}
    		}
    	}
    
    	public static void TestMethod(string a, ref TEnum b)
    	{
    		Console.WriteLine("test");
    	}
    }
    
    public enum TEnum
    {
    	Test,
    	Test2
    }
