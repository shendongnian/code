    using System;
    using System.Text;
    using System.IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		dynamic result = JObject.Parse(json);
    		var obj1 = result.people.name;
    		foreach (var prop1 in obj1)
    		{
    			Console.WriteLine(prop1.Name);
    			foreach (var obj2 in prop1)
    			{
    				foreach (var prop2 in obj2)
    				{
    					Console.WriteLine(prop2.Name + ": " + prop2.Value);
    				}
    			}
    		}
    	}
    }
