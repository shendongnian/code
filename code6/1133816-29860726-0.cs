    using System;
    using Newtonsoft.Json;
    
    public class Program
    	
    {
    	private static string fakeConfigFile = @"{
    		ServerAddress: null,
    		ServerPort: null,
    		ServerTimeout: null
    	}";
    	
    	public static void Main()
    	{
    		ConfigFile f = JsonConvert.DeserializeObject<ConfigFile>(fakeConfigFile);
    		
    		f.ServerAddress = "0.0.0.0";
    		f.ServerPort = "8080";
    		f.ServerTimeout = "400";
    		
    		Console.WriteLine(f.ServerAddress);
    		Console.WriteLine(f.ServerPort);
    		Console.WriteLine(f.ServerTimeout);
    	}
    	
    	class ConfigFile
        {
            public string ServerAddress { get; set; }
            public string ServerPort { get; set; }
    		public string ServerTimeout { get; set; }
        }
    }
