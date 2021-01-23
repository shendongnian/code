    using System;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var str ="{\"identifier\":7,\"name\":\"xyzstr\"}";
    		DBModel dbModel = JsonConvert.DeserializeObject<DBModel>(str);
    		Console.WriteLine(dbModel.identifier);
    		Console.WriteLine(dbModel.name);
    		
    	}
    }
    
    public class DBModel
    {
       public int identifier { get; set; }
       public string name { get; set; }
    	
    
    }
