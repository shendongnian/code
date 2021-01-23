    using System;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string[] array = JsonConvert.DeserializeObject<String[]>("[\"String1\",\"String2\",\"String3\"]");
    		
    		foreach (string item in array)
    			Console.WriteLine(item);
    	}
    }
