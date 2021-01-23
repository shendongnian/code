    using System;
    using System.Text;
    					
    public class Program
    {
    	public static StringBuilder StaticString;
    	public StringBuilder InstanceString;
    
    	public static void Main()
    	{
    		Program.StaticString = new StringBuilder("foo");
    	
    		var p = new Program();
    		p.InstanceString = Program.StaticString;
    		
    		Console.WriteLine("Changing the object at which the value points:");
    		Program.StaticString.Append("bar");
    		Console.WriteLine(p.InstanceString);
    		Console.WriteLine(Program.StaticString);
    		
    		Console.WriteLine("\nChanging the value:");
    		Program.StaticString = new StringBuilder("raboof");
    		Console.WriteLine(p.InstanceString);
    		Console.WriteLine(Program.StaticString);
    	}
    }
