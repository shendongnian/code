    //ModuleA
    container.RegisterType<IRegionManager, RegionManagerA>("RegionManagerA")
    //ModuleB
    container.RegisterType<IRegionManager, RegionManagerB>("RegionManagerB")
    //Some other point in Module B
    //Resolve the specific RegionManager for Module B
    DependencyOverride rm = new DependencyOverride(typeof(IRegionManager)
                             ,container.Resolve<IRegionManager>("RegionManagerB")); 
    //and pass that as a dependency when the SearchViewModel is resolved
    SearchViewModel vm = container.Resolve<SearchViewModel>(rm);
