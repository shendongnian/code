    public interface IRepositoryProvider
    {}
    public class RepositoryProvider : IRepositoryProvider
    {
        private IRepositoryFactories _factories;
        private string _name;
        
        public RepositoryProvider(IRepositoryFactories factories) {
            _factories = factories;
        }
        public RepositoryProvider(string name) {
            _name = name;
        }
    }
    public interface IRepositoryFactories { }
    public class RepositoryFactories : IRepositoryFactories{}
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration("MyContainer");
            var instance = container.
                               Resolve<IRepositoryProvider>("RepositoryProvider");
        }
    }
 
