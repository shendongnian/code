    public class MyDbContext : DbContext, IMyDbContext
    {
        public MyDbContext() : base("name=SQLAzureConnection")
        {
        }
    
        IMyDbContext.Dispose() // Implement it via explicit implementation
        {
    
        }
    }
