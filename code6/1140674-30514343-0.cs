      static class Program
      {
        static void Main()
        {
          Controller win = new Controller();
          win.ListPlugins();
        }
      }
    
      public class Controller
      {
        [System.ComponentModel.Composition.ImportMany]
        IEnumerable<Lazy<Interface.IPlugin>> plugins;
    
        System.ComponentModel.Composition.Hosting.CompositionContainer compContainer;
    
        public Controller()
        {
          var catalog = GetMefCatalogs();
          this.compContainer = new System.ComponentModel.Composition.Hosting.CompositionContainer(catalog);
    
          try
          {
            System.ComponentModel.Composition.AttributedModelServices.ComposeParts(this.compContainer, this);
          }
          catch (System.Reflection.ReflectionTypeLoadException ex)
          {
            foreach (Exception inner in ex.LoaderExceptions)
            {
              Console.WriteLine("Reflection error: {0}", inner.Message);
            }
          }
          catch (System.ComponentModel.Composition.CompositionException ex)
          {
            Console.WriteLine(ex.ToString());
          }
    
        }
    
        public void ListPlugins()
        {
          foreach (var pv in this.plugins)
          {
            Console.WriteLine(pv.Value.Name);
          }
        }
    
        public static System.ComponentModel.Composition.Hosting.AggregateCatalog GetMefCatalogs()
        {
          var catalog = new System.ComponentModel.Composition.Hosting.AggregateCatalog();
          // You should probably use these two lines, or the following lines, but not both.  If you use
          // this option you will need to ensure that the libs are all in the same directory.
          catalog.Catalogs.Add(new System.ComponentModel.Composition.Hosting.DirectoryCatalog(System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory), "*.dll"));
          catalog.Catalogs.Add(new System.ComponentModel.Composition.Hosting.DirectoryCatalog(System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory), "*.exe"));
          //foreach (var assembly in System.AppDomain.CurrentDomain.GetAssemblies())
          //{
          //  if (!assembly.FullName.StartsWith("System", StringComparison.OrdinalIgnoreCase) &&
          //    !assembly.FullName.StartsWith("Microsoft", StringComparison.OrdinalIgnoreCase) &&
          //    !assembly.FullName.StartsWith("mscorlib", StringComparison.OrdinalIgnoreCase) &&
          //    !assembly.FullName.StartsWith("Accessibility", StringComparison.OrdinalIgnoreCase) &&
          //    !assembly.FullName.StartsWith("vshost32", StringComparison.OrdinalIgnoreCase))
          //  {
          //    Console.WriteLine("Found assembly: " + assembly.FullName);
          //    catalog.Catalogs.Add(new System.ComponentModel.Composition.Hosting.AssemblyCatalog(assembly));
          //  }
          //}
          return catalog;
        }
      }
