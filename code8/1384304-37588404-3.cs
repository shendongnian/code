    public class FirstPlugin : IPlugin {
        const string Name = "First Plugin";
        public void Init(IHostController host) {
            Console.WriteLine(Name + " initialized");
        }
        public void Start() {
            Console.WriteLine(Name + " started");
        }
        public void Stop() {
            Console.WriteLine(Name + " stopped");
        }
    }
