    public class MYContext : DbContext {
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Ignore<MenuItem_URL>();
        }
    
    ...
    
    }
