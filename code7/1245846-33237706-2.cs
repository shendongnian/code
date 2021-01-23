    public class EFDbContext: DbContext 
    { 
        public EFDbContext() 
        { 
            this.Configuration.LazyLoadingEnabled = false; 
        } 
    }
