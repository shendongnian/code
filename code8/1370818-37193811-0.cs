        public class BootStrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<Shell>();
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }
        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(BootStrapper).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(RegionNames).Assembly));
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ModuleMenu.Module).Assembly));
            //Added catalog 
            //--> 
                AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(ServiceFactory).Assembly));
        }
    }
