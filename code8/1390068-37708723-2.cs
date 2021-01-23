    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string json = @"
                {
                    ""price"": [""123.50"", ""124.6"", ""126.30""],
                    ""order"": [""23"", ""30"", ""20""]
                }";
    		
    		try
    		{
    			Product prod = JsonConvert.DeserializeObject<Product>(json);
    			foreach (var kvp in prod.priceInfo)
    			{
    				Console.WriteLine(kvp.Key + ": " + kvp.Value);
    			}
    			foreach (var kvp in prod.orderInfo)
    			{
    				Console.WriteLine(kvp.Key + ": " + kvp.Value);
    			}
    		}
    		catch (Exception e)
    		{
    			Console.WriteLine(e.Message);
    			if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
    		}
    	}
    }
