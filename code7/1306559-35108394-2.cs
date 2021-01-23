    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var typesToUse = new Type[] { typeof(int), typeof(string) };
    		var methods = typeof(A).GetMethods().Where(m => m.Name == "Foo");
    		
    		var matchingMethods = methods.Where(m => ContainsAllParameters(m, typesToUse));
    		
    		Console.WriteLine(matchingMethods.Single());
    	}
    	
    	private static bool ContainsAllParameters(MethodInfo method, Type[] typesToUse) 
    	{
    		var methodTypes = method.GetParameters().Select(p => p.ParameterType).ToList();
    		
    		foreach(var typeToUse in typesToUse)
    		{
    			if (methodTypes.Contains(typeToUse))
    			{
    				methodTypes.Remove(typeToUse);
    			}
    			else 
    			{
    				return false;		
    			}
    		}
    		
    		return !methodTypes.Any();
    	}
    	
    }
    
    public class A
    {
    	public void Foo(string a, int b) 
    	{
    		Console.WriteLine("Hello World");
    	}
    }
