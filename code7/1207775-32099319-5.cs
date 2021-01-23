    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Common;
    
    namespace SOMEF
    {
        public class PluginsCatalog
        {
            [ImportMany]
            public Lazy<IConnector, ConnectorMetadata>[] Connectors;
    
            private static readonly Lazy<PluginsCatalog> LazyInstance = new Lazy<PluginsCatalog>(() => new PluginsCatalog());
    
            private PluginsCatalog()
            {
                var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
    
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? Directory.GetCurrentDirectory();
                var directoryCatalog = new DirectoryCatalog(path, "*plugin.dll");
    
                var aggregateCatalog = new AggregateCatalog(assemblyCatalog, directoryCatalog);
    
                var container = new CompositionContainer(aggregateCatalog);
                container.SatisfyImportsOnce(this);
            }
    
            public static PluginsCatalog Instance { get { return LazyInstance.Value; } }
    
            public IConnector GetConnector(string name)
            {
                var match = Connectors.SingleOrDefault(s => s.Metadata.Name.Equals(name));
                return match == null ? null : match.Value;
            }
        }
    }
