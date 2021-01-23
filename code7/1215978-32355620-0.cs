    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.IO;
    using System.Reflection;
    using ConsoleApplication;
    
    namespace ConsoleApplication
    {
        public interface IFetchService
        {
            void Write();
        }
    
        class PluginManager
        {
            [ImportMany(typeof(IFetchService))]
            public  IFetchService[] PluginList;
    
            public PluginManager()
            {
                var dirCatalog = new DirectoryCatalog(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Test");
    
                var pluginCatalog = new AggregateCatalog(dirCatalog);
                var compositionContainer = new CompositionContainer(pluginCatalog);
                compositionContainer.ComposeParts(this);
             } 
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var pluginManager = new PluginManager();
    
                foreach (var fetchService in pluginManager.PluginList)
                {
                    fetchService.Write();
                }
    
                Console.ReadKey();
            }
        }
    }
    
    // Separate class library
    namespace PluginNameSpace
    {
        [Export(typeof(IFetchService))]
        public class MySamplePlugin : IFetchService
        {
            public void Write()
            {
                Console.WriteLine("Plugin entered");
            }
        }
    }
