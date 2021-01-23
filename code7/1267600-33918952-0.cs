    using System;
    using Newtonsoft.Json.Linq;
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			string json =
				"{\"id\": \"1012718\", \"links\": {\"self\": \"https://www.google.com\"}, \"mention_name\": \"NeerajGupta\", \"name\": \"Neeraj Gupta\", \"version\": \"00000000\"}";
			dynamic data = JObject.Parse(json);
			Console.WriteLine(data.name);
		}
	}
    }
