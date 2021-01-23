	 /// <summary>
	 /// Convenience getter for Project.Properties.
	 /// Examples:
	 /// <code>string thisAssemblyName = config.Properties.Item("AssemblyName").Value.ToString();</code>
	 /// <code>string thisAssemblyName = config.Properties.Item("AssemblyName").Value.ToString();</code>
	 /// </summary>
	 /// <remarks>see http://msdn.microsoft.com/en-us/library/envdte.project_properties.aspx</remarks>
	 public EnvDTE.Properties Properties
	 {
	  get { return _project.Properties;}
	 }
>	  
	 /// <summary>
	 /// Provides access to the application/web configuration file.
	 /// </summary>
	 /// <remarks>see http://msdn.microsoft.com/en-us/library/system.configuration.configuration.aspx</remarks>
	 public System.Configuration.Configuration Configuration
	 {
	  get { return _configuration; }
	 }
