    class ModManager
    {
        [ImportMany(typeof(Mod))]
        public static IEnumerable<Mod> Mods { get; set; }
        public List<Mod> LoadedMods { get; set; } 
        CompositionContainer _container;
        public ModManager()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(CoreMod).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(
                Path.GetDirectoryName(
                    new Uri(Assembly.GetExecutingAssembly()
                                   .CodeBase).LocalPath)));
            _container = new CompositionContainer(catalog);
            this._container.ComposeParts(this);
            this.LoadedMods = this.Mods.ToList();
        }
    }
