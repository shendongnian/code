	class DatabaseSettings
	{
		// Settings file path
		private const string DEFAULT_FILENAME = "settings.json";
		// Server name or IP
		public string Server { get; set; } = "127.0.0.1";
		// Port
		public int Port { get; set; } = 3306;
		// Login
		public string Login { get; set; } = "root";
		// Password
		public string Password { get; set; }
		
		public void Save(string fileName = DEFAULT_FILENAME)
		{
			File.WriteAllText(
				fileName,
				(new JavaScriptSerializer()).Serialize(this));
		}
		
		public static DatabaseSettings Load(string fileName = DEFAULT_FILENAME)
		{
			var settings = new DatabaseSettings();
			if (File.Exists(fileName))
				settings = (new JavaScriptSerializer()).Deserialize<DatabaseSettings>(File.ReadAllText(fileName));
			return settings;
		}
	}
