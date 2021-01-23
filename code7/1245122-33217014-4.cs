    public interface IDocumentRepositoryFactory
    {
        IDocumentRepository Create(Context context);
    }
    public class SharePointDocumentRepositoryFactory : IDocumentRepositoryFactory
    {
        public IDocumentRepository Create(Context context)
        {
            //Create the repository
            SharePointContext spContext = SharePointContextProvider.Current.GetSharePointContext(....);
            using(var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                return new SharePointDocumentRepository(clientContext); 
            }
        }
    }
