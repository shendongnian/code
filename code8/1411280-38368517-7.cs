    public class Service : IService
        {
            private ISomeRepository _someRepository; // Exposed instance of my repo
    
            public IEnumerable<SomeClass> FindAll()
            {
                return _someRepository.FindAll();
            }
        }
