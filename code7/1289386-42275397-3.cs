    protected override IModuleCatalog CreateModuleCatalog()
    {
        return Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml(
            new Uri("/ProjectNameHere;component/XamlCatalog.xaml", UriKind.Relative));
    }
