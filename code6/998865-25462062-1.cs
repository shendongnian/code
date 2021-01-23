  	 /// <summary>
	 /// Typical usage from T4 template:
	 /// <code>ConfigurationAccessor config = new ConfigurationAccessor((IServiceProvider)this.Host);</code>
	 /// </summary>
	 public ConfigurationAccessor(IServiceProvider host) : this(host, null)
	 {  }
>	 
	 /// <summary>
	 /// Same as default constructor but it looks for a web.config/app.config in the passed config
	 /// project location and not in the first startup project it finds. The configProjectLocation
	 /// passed should be relative to the solution file.
	 /// </summary>
	 public ConfigurationAccessor(IServiceProvider host, string configProjectLocation)
	 {
	  // Get the instance of Visual Studio that is hosting the calling file
	  EnvDTE.DTE env = (EnvDTE.DTE)host.GetService(typeof(EnvDTE.DTE));
