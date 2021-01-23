    public interface IDocumentRepositoryIsolationFactory
    {
        void CreateAndUse(Context context, Action<IDocumentRepository> action);
    }
    public class SharePointDocumentRepositoryIsolationFactory : IDocumentRepositoryIsolationFactory
    {
        public void CreateAndUse(Context context, Action<IDocumentRepository> action)
        {
            //Create the repository
            SharePointContext spContext = SharePointContextProvider.Current.GetSharePointContext(....);
            using(var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                var repository = SharePointDocumentRepository(clientContext); 
                action(repository);
            }
        }
    }
