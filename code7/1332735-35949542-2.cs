    using System.Data.Entity;
    using YourProject.Data.Models;
    namespace YourProject.Data.DAL
    {
        public class YourContext : DbContext
        {
            public YourContext() : base("ConnectionStringName")
            {
    
            }
        
            public DbSet<ModelA> ModelAs { get; set; }
            public DbSet<ModelB> ModelBs { get; set; }
    
        }
    }
