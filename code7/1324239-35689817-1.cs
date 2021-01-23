    class Program
    {
        static void Main()
        {
            // will output 'Hi from MyPlugin!' when resolved.
            var myPlugin = MefFactory.Create<IMyPlugin>().Value;
    
            // will output 'Hi from MyOtherPlugin!' when resolved.
            var myOtherPlugin = MefFactory.Create<IMyOtherPlugin>().Value;
    
            Console.ReadLine();
        }
    }
    
    public static class MefFactory
    {
        private static readonly CompositionContainer Container = CreateContainer();
    
        public static Lazy<T> Create<T>()
        {
            return Container.GetExport<T>();
        }
    
        private static CompositionContainer CreateContainer()
        {
            // directory where all the dll's reside.
            string directory = AppDomain.CurrentDomain.BaseDirectory;
    
            var container = new CompositionContainer( new DirectoryCatalog( directory ) );
    
            return container;
        }
    }
