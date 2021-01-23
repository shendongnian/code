        #region Attributes
		private ManualAssemblyResolver _resolver;
		#endregion
		#region Override Microsoft.VisualStudio.Shell.Package
		/// <summary>
		/// Initialization of the package; this method is called right after the package is sited, so this is the place
		/// where you can put all the initialization code that rely on services provided by VisualStudio.
		/// </summary>
		protected override void Initialize()
		{
			_resolver = new ManualAssemblyResolver(
			Assembly.LoadFrom(Path.Combine(ExtensionManager.Instance.InstallationPath, Definitions.Constants.NameOfAssemblyA)),
			Assembly.LoadFrom(Path.Combine(ExtensionManager.Instance.InstallationPath, Definitions.Constants.NameOfAssemblyB))
			);
			
