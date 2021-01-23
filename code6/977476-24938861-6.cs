    public class EfContext : DbContext
    {              
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {           
            modelBuilder.Configurations.Add(new CardContainerConfiguration());
            modelBuilder.Configurations.Add(new ChassisConfiguration());
            modelBuilder.Configurations.Add(new CardConfiguration());           
    
            base.OnModelCreating(modelBuilder);
        }
    }
 
