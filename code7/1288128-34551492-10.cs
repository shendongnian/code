    protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(LoginViewModel).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(LoginView).Assembly));
            this.mvvmTypeLocator = new MvvmTypeLocator(this.AggregateCatalog);
        }
