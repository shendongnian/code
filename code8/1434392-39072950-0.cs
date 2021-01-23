    public interface IRepositoryResolver
    {
        IRepository GetRepositoryByName(string name);
    }
    public class RepositoryResolver : IRepositoryResolver 
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositoryResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IRepository GetRepositoryByName(string name)
        {
             if(name == "TestSuiteRepository") 
               return _serviceProvider.GetService<TestSuiteRepositor>();
             //... other condition
             else
               return _serviceProvider.GetService<BaseRepositor>();
        }
       
    }
    
