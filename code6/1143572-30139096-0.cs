    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var json = "{\"response\":[{\"id\":269058571,\"first_name\":\"Name\",\"last_name\":\"LastName\",\"photo_50\":\"http://cs624717.vk.me/v624717571/21718/X8.jpg\"}]}";
    		
    		var obj = JsonConvert.DeserializeObject<RootObject>(json);
    		
    		foreach(var item in obj.response) {
    			Console.WriteLine(item.first_name);
    		}    		
    	}
    }
    
    class RootObject
    {
    	public List<Item> response { get; set; }
    }
    class Item
    {
    	public string first_name { get; set; }
    	public string last_name { get; set; }
    	public string domain { get; set; }
    	public string photo_50 { get; set; }
    }
