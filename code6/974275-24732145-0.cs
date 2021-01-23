    public class MyControllerWithDbDependency : Controller
    {
       MyControllerWithDbDependency(IFileSystemServiceFactory fileSystemServiceFactory)
       {
          _service = fileSystemServiceFactory.Create("MyDbFileSystemServiceFactory");
       }
    }
    public interface IFileSystemServiceFactory
    {
        IFileSystemServiceFactory Create(string dependencyName);
    }
    public class AutoFacFileSystemServiceFactory : IFileSystemService
    {
        private readonly IComponentContext _componentContext;
    
        public AutoFacFileSystemServiceFactory(IComponentContext componentContext)
        {
            if (componentContext == null) throw new ArgumentNullException("componentContext");
            _componentContext = componentContext;
        }
    
        public IFileSystemService Create(string dependencyName)
        {
            return _componentContext.ResolveNamed<IFileSystemService>(dependencyName);
        }
    }
