    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    	
          List<JsonModel> ListJson1 = new List<JsonModel>();
          ListJson1.Add(new JsonModel(1, new List<string>(new string[] {"a", "b", "c"})));
          ListJson1.Add(new JsonModel(2, new List<string>(new string[] {"apple", "pear"})));
          ListJson1.Add(new JsonModel(3, new List<string>(new string[] {"blue", "red"})));
    
          List<JsonModel> ListJson2 = new List<JsonModel>();
          ListJson2.Add(new JsonModel(2, new List<string>(new string[] {"tomato"})));
          ListJson2.Add(new JsonModel(3, new List<string>(new string[] {"pink", "red"})));
          ListJson2.Add(new JsonModel(4, new List<string>(new string[] {"x", "y", "z"})));
    		
    		List<JsonModel> result = ListJson1.Concat(ListJson2)
    								.ToLookup(p => p.Index)
    								.Select(g => g.Aggregate((p1,p2) =>	 
    														 new JsonModel(p1.Index,p1.Names.Union(p2.Names)))).ToList();
    
    		foreach(var item in result)
    		{
    		Console.WriteLine(item.Index);
    			foreach(var Item in item.Names)
    				Console.WriteLine(Item);
    		}
    	}
    	
    	
    }
     
    							
    public class JsonModel
        {
          public  int Index;//you can use your private set and public get here
          public  IEnumerable<string> Names;//you can use your private set and public get here
    
          public JsonModel(int index, IEnumerable<string> names)
          {
            Index = index;
            Names = names;
          }
    
        }
  
