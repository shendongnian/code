            private void startup()
        {
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly().Location);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            foreach (var resultsRepository in this.repositories)
            {
                Debugger.Break();
            }
        }
        [ImportMany]
        public List<IResultsRepository> repositories { get; set; }
    }
