	 private EnvDTE.Project _project;
	 private System.Configuration.Configuration _configuration;
>	  
	 /// <summary>
	 /// Provides access to the host project.
	 /// </summary>
	 /// <remarks>see http://msdn.microsoft.com/en-us/library/envdte.project.aspx</remarks>
	 public EnvDTE.Project Project
	 {
	  get { return _project; }
	 }
