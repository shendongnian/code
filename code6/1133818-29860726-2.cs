    using System;
    using Newtonsoft.Json;
    public class Program
    {
    	public static void Main()
    	{
    		ConfigFile f = ConfigFile.Load();
    		f.ServerAddress = "0.0.0.0";
    		f.ServerPort = "8080";
    		f.ServerTimeout = "400";
    		f.Save();
    	}
    	
    	public class ConfigFile
        {
    		private readonly static string path = "somePath.json";
            public string ServerAddress { get; set; }
            public string ServerPort { get; set; }
    		public string ServerTimeout { get; set; }
    		public void Save()
    		{
    			var fileContent = JsonConvert.SerializeObject(this);
    			Console.WriteLine(fileContent);
    		}
    		public static ConfigFile Load()
    		{
    			var fileContents = @"{ 
    			    ServerAddress: null, 
    				ServerPort: null, 
    				ServerTimeout: null }";
    		    return JsonConvert.DeserializeObject<ConfigFile>(fileContents);
    		}
        }
    }
