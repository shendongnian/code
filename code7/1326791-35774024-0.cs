    public class Program
    {
        private static void Main(string[] args)
        {
            var listener = new Listener();
            var otherDomain = AppDomain.CreateDomain("otherDomain");
    
            var instance = (Loader)otherDomain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(Loader).FullName);
            instance.Init(listener);
        }
    }
    
    [Serializable]
    public class Loader 
        : MarshalByRefObject
    {
        public void Init(Listener listener)
        {
            Console.WriteLine($"[{nameof(Init)}] Hello from {AppDomain.CurrentDomain.FriendlyName} domain");
            listener.Calback();
        }
    }
    
    [Serializable]
    public class Listener 
        : MarshalByRefObject
    {
        public void Calback()
        {
            Console.WriteLine($"[{nameof(Calback)}] Hello from {AppDomain.CurrentDomain.FriendlyName} domain");
        }
    }
