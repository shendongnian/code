    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    
    public class Program
    {
    	public static void Main()
    	{
    		string tsi = "[{\"name\":\"ts.DatumVon\",\"value\":\"29.10.2015\"},{\"name\":\"ts.Von\",\"value\":\"8:00\"},{\"name\":\"ts.Bis\",\"value\":\"16:30\"}]";
    
    		var attributes = JsonConvert.DeserializeObject<List<NameValuePair>>(tsi);
    		attributes = attributes
    			.Select(item => new NameValuePair {	Name = item.Name.Replace("ts.", ""), Value = item.Value	})
    			.ToList();
    		
    		var newJson = "{" + String.Join(",", attributes.Select(item => String.Format("\"{0}\":\"{1}\"", item.Name, item.Value))) + "}";
    		
    		Console.WriteLine(newJson);
    
    		var ts = JsonConvert.DeserializeObject<TimeSaver>(newJson);
    
    		Console.WriteLine(ts.DatumVon);
    		Console.WriteLine(ts.Von);
    		Console.WriteLine(ts.Bis);
    	}
    }
    
    public class NameValuePair
    {
    	public string Name { get; set; }
    	public string Value	{ get; set; }
    }
    
    public class TimeSaver
    {
    	public String DatumVon { get; set; }
    	public TimeSpan Von { get; set; }
    	public TimeSpan Bis { get; set; }
    }
