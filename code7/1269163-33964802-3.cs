    public class ApplicationBootstrapper : UnityBootstrapper
    {
        protected override IModuleCatalog CreateModuleCatalog()
        {
            var moduleCatalog = new ModuleCatalog();
            moduleCatalog.AddModule(typeof(YourCompany.MyModule.MyExternalModule), InitializationMode.WhenAvailable);
            return moduleCatalog;
        }
        ...
    }
