    // this is your host
    public interface IHostController {
        // names of all loaded plugins
        string[] Plugins { get; }
        void StartPlugin(string name);
        void StopPlugin(string name);
    }
    public interface IPlugin {
        // with this method you will pass plugin a reference to host
        void Init(IHostController host);
        void Start();
        void Stop();                
    }
    // helper class to combine app domain and loader together
    public class PluginInfo {
        public AppDomain Domain { get; set; }
        public RemoteLoader Loader { get; set; }
    }
