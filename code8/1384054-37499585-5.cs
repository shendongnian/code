    public class SomeModelViewModel
    {
        private ISomeModelRepositoryService _RepositoryService;
        public SomeModel Model { get; set; }
        public SomeModelViewModel(ISomeModelRepositoryService repositoryService)
        {
            _RepositoryService = repositoryService;
        }
        public void Save()
        {
            _RepositoryService.Save(this.Model);
        }
    }
