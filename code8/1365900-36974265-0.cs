    internal class ActiveDirectoryRepository : IActiveDirectoryRepository
    {
        private readonly string _container;
        public ActiveDirectoryRepository(IOptions<WebAppSettings> settings)
        {
            _container = settings.Value.ContainerDomain;
        }
    }
