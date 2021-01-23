    public class ApplicationDbContextFactory
    {
        public static IApplicationDbContext Create(IOwinContext owinContext)
        {
            return ApplicationDbContext.Create(owinContext);
        }
    }
