        public class YourDbContext : DbContext
        {
            public YourDbContext() : ("YourDbConnectionStringName")
            {
            }
            
            // Definitions of valid Entity Framework objects
            public virtual IDbSet<User> Users { get; set; }
            public virtual IDbSet<Image> Images { get; set; }
        }
    
        var dbContext = new YourDbContext();
    
        var imageViewModel = new ImageViewModel();
        var imageDomainModel = new Image();
    
        // Adding object defined within your db context is fine...
        dbContext.Set<Image>().Add(imageDomainModel); // OK
        dbContext.Set<Image>().Add(imageViewModel); // Not OK, will result in exception
