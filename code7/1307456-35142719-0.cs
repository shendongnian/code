    public class AmazonProductCollectionFactory : IAmazonProductCollectionFactory
    {
        private readonly IResolutionRoot m_ResolutionRoot;
        public AmazonProductCollectionFactory (IResolutionRoot resolution_root)
        {
            m_ResolutionRoot = resolution_root;
        }
        public AmazonProductCollection Create(string title, int pageNumber, int itemsPerPage)
        {
            return resolution_root.Get<AmazonProductCollection>(
                new ConstructorArgument("title", title),
                new ConstructorArgument("pageNumber", pageNumber),
                new ConstructorArgument("itemsPerPage", pageNumber));
        }
    }
