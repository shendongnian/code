    // note : inherits from MarshalByRefObject and implements interface
    public class HostController : MarshalByRefObject, IHostController {        
        private readonly Dictionary<string, PluginInfo> _plugins = new Dictionary<string, PluginInfo>();
        public void ScanAssemblies(params string[] paths) {
            foreach (var path in paths) {
                var setup = new AppDomainSetup();                
                var domain = AppDomain.CreateDomain(Path.GetFileNameWithoutExtension(path), null, setup);
                var assemblyPath = Assembly.GetExecutingAssembly().Location;
                var loader = (RemoteLoader) domain.CreateInstanceFromAndUnwrap(assemblyPath, typeof (RemoteLoader).FullName);
                // you are passing "this" (which is IHostController) to your plugin here
                loader.Init(this, path);                          
                _plugins.Add(loader.Name, new PluginInfo {
                    Domain = domain,
                    Loader = loader
                });
            }
        }
        public string[] Plugins => _plugins.Keys.ToArray();
        public void StartPlugin(string name) {
            if (_plugins.ContainsKey(name)) {
                var p = _plugins[name].Loader;
                if (!p.IsStarted) {
                    p.Start();
                }
            }
        }
        public void StopPlugin(string name) {
            if (_plugins.ContainsKey(name)) {
                var p = _plugins[name].Loader;
                if (p.IsStarted) {
                    p.Stop();
                }
            }
        }
    }
