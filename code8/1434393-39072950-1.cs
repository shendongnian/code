    public class BaselineManager
    {
        private readonly IRepository _repository;
        public BaselineManager(IRepositoryResolver repositoryResolver)
        {
            _repository = repositoryResolver.GetRepositoryByName("TestSuiteRepository");
        }
    }
