    class ModulesLoader
    {
        [ImportMany(typeof(ISchedulable))]
        public IEnumerable<ISchedulable> Modules { get; set; }
        private string dir;
		private string name;
		public ModulesLoader(string directory, string name)
        {
            Assert.ThrowIfEmptyString(directory);
			Assert.ThrowIfNull (name);
            this.dir = directory;
			this.name = name;
        }
        public void Load()
        {
			var catalog = new AggregateCatalog();
			var assembly = GetType ().Assembly; //Assembly of our executable program
			var dllCatalog = new AssemblyCatalog (assembly);
			catalog.Catalogs.Add(dllCatalog);
			var pluginAssembly = Assembly.LoadFrom (Path.Combine (dir, name)); //We have to explicit point which assembly will be loaded
			var pluginCatalog = new AssemblyCatalog (pluginAssembly); //pass it to catalog to let framework know each vital information about this .dll
			catalog.Catalogs.Add (pluginCatalog);
			CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this); //and it works!
        }
    }
