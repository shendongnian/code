    public partial class App : Application
    {
	    private CompositionContainer _container;
        protected override void OnStartup(StartupEventArgs e)
	    {
		    var path = Path.GetDirectoryName("Your destination on C:");
		    var catalog = new DirectoryCatalog(path);
  		    _container = new CompositionContainer(catalog, CompositionOptions.DisableSilentRejection);
		    _container.SatisfyImportsOnce(this);
		
		    var resourceDictionaries = _container.GetExports<ResourceDictionary>();
		
            foreach (var resourceDictionary in resourceDictionaries)
            {
			    Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }
	    }
    }
