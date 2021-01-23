	 /// <summary>
	 /// Provides access to the appSettings section of the configuration file.
	 /// Behavior differs from typical AppSettings usage in that the indexed
	 /// item's .Value must be explicitly addressed.
	 /// <code>string setting = config.AppSettings["MyAppSetting"].Value;</code>
	 /// </summary>
	 /// <remarks>see http://msdn.microsoft.com/en-us/library/system.configuration.configuration.appsettings.aspx</remarks>
	 public  KeyValueConfigurationCollection AppSettings
	 {
	  get { return _configuration.AppSettings.Settings;}
	 }
>	  
	 /// <summary>
	 /// Provides access to the connectionStrings section of the configuration file.
	 /// Behavior is as expected; items are accessed by string key or integer index.
	 /// <code>string northwindProvider = config.ConnectionStrings["northwind"].ProviderName;</code>
	 /// </summary>
	 /// <remarks>see http://msdn.microsoft.com/en-us/library/system.configuration.configuration.connectionstrings.aspx</remarks>
	 public  ConnectionStringSettingsCollection ConnectionStrings
	 {
	  get { return _configuration.ConnectionStrings.ConnectionStrings;}
	 }
	}
	#>
