	public class ConfigFile
    {
		private readonly static string path = "somePath.json";
        public string ServerAddress { get; set; }
        public string ServerPort { get; set; }
		public string ServerTimeout { get; set; }
		public void Save()
		{
			var json = JsonConvert.SerializeObject(this, Formatting.Indented);
			File.WriteAllText(path, json) 
		}
		public static ConfigFile Load()
		{
            var json = File.ReadAllText(path); 
		    return JsonConvert.DeserializeObject<ConfigFile>(json);
		}
    }
