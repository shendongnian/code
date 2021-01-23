    public class YourDbContext: DbContext 
    { 
        public YourDbContext () 
        { 
            this.Configuration.LazyLoadingEnabled = false; 
        } 
    }
