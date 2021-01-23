		using System;
		using Newtonsoft.Json;
					
		public class Program
		{
			// create you class. You can generate it with http://json2csharp.com/ or use Visual Studio (edit>past special)
			public class Custom
			{
    			public string Url { get; set; }
    			public string Name { get; set; }
    			public string Id { get; set; }
			}
	
			public void Main()
    		{
				string json = "{ \"Url\":\"xyz.com\", \"Name\":\"abc\", \"ID\":\"123\" }";
				// the magic code is here! Go to http://www.newtonsoft.com/json for more information
				Custom custom = JsonConvert.DeserializeObject<Custom>(json);
				
				// custom is fill with your json!
				Console.WriteLine(custom.Name);
    		}
		}
