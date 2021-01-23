    using System;
    using Newtonsoft.Json;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Foo foo = new Foo { Date = DateTime.Now };
    		
    		JsonSerializerSettings settings = new JsonSerializerSettings
    		{
    			DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
    			Formatting = Formatting.Indented
    		};
    		
    		string json = JsonConvert.SerializeObject(foo, settings);
    		Console.WriteLine(json);
    		
    		foo = JsonConvert.DeserializeObject<Foo>(json, settings);
    		Console.WriteLine(foo.Date.ToString());
    	}
    }
    
    class Foo
    {
    	public DateTime Date { get; set; }
    }
