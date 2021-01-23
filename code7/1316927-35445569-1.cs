    public class YourContext : DbContext 
    { 
        public YourContext() 
        { 
            this.Configuration.LazyLoadingEnabled = false; 
            this.Configuration.ProxyCreationEnabled = false; 
        } 
    }
