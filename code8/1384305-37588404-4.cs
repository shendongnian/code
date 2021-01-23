    public class FirstPlugin : IPlugin {
        const string Name = "Second Plugin";
        private Timer _timer;
        private IHostController _host;
        public void Init(IHostController host) {
            Console.WriteLine(Name + " initialized");
            _host = host;
        }
        public void Start() {
            Console.WriteLine(Name + " started");
            Console.WriteLine("Will try to restart first plugin every 5 seconds");
            _timer = new Timer(RestartFirst, null, 5000, 5000);
        }
        int _iteration = 0;
        private void RestartFirst(object state) {
            // here we talk with a host and request list of all plugins
            foreach (var plugin in _host.Plugins) {
                Console.WriteLine("Found plugin " + plugin);
            }
            if (_iteration%2 == 0) {
                Console.WriteLine("Trying to start first plugin");
                // start another plugin from inside this one
                _host.StartPlugin("Plugin1");
            }
            else {
                Console.WriteLine("Trying to stop first plugin");
                // stop another plugin from inside this one
                _host.StopPlugin("Plugin1");
            }
            _iteration++;
        }
        public void Stop() {
            Console.WriteLine(Name + " stopped");
            _timer?.Dispose();
            _timer = null;
        }
    }
