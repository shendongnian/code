    public class Mef
    {
        private static CompositionContainer container = null;
        public static CompositionContainer Container { get { return container; } }
        private static AggregateCatalog catalog;
        public static void Initialize()
        {
            catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(path: ".", searchPattern: "*.exe"));
            catalog.Catalogs.Add(new DirectoryCatalog(path: ".", searchPattern: "*.dll"));
            container = new CompositionContainer(catalog);
            StartWatch();
        }
        private static void StartWatch()
        {
            var watcher = new FileSystemWatcher() { Path = ".", NotifyFilter = NotifyFilters.LastWrite };
            watcher.Changed += (s, e) =>
            {
                string lName = e.Name.ToLower();
                if (lName.EndsWith(".dll") || lName.EndsWith(".exe"))
                    Refresh();
            };
            watcher.EnableRaisingEvents = true;
        }
        public static void Refresh()
        {
            foreach (DirectoryCatalog dCatalog in catalog.Catalogs)
                dCatalog.Refresh();
        }
    }
