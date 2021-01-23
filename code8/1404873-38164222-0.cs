	class PluginConfiguration {
		public string PluginName {get; private set;} // This represents a property that all plugins share i.e. well known properties
		
		// all the configurations "private" to the plugin can go here
		// You might want to use some XmlDocument or a different data structure for this purpose
		public Dictionary<string,string> ConfigItems {get; private set;}
		
		public PluginConfiguration(string configFile) {
			// Load the configuration from the config file
		}	
	}
