    protected override void ConfigureAggregateCatalog()
    {
        base.ConfigureAggregateCatalog();
        this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleA).Assembly));
        this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleC).Assembly));
        . . .
    }
