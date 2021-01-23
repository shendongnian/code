    namespace Dashboard.Domain.Factories
    {
        public interface IRepoCollectionFactory
        {
            IRepositoryCollection CreateCollection(List<string> connectionStrings);
        }
    }
