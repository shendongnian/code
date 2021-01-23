    public class SomeContext : DbContext 
    { 
        public SomeContext() 
        { 
            this.Configuration.LazyLoadingEnabled = false; 
        } 
    }
