    public interface IDefaultContextFactory : IDbContextFactory<CMSContext> {}
    
    public class DefaultContextFactory : IDefaultContextFactory 
    {
        private readonly Lazy<CMSContext> lazyContext = new Lazy<CMSContext>(() => new CMSContext());
    
        public CMSContext Create() 
        {
            return lazyContext.Value;
        }
    }
