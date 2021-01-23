    public class AppContext : DbContext
    {   
        public override int SaveChanges()
        {
           var addedAttitudes = ChangeTracker.Entries<Attitude>()
              .Where(q => q.State == EntityState.Added);
           foreach (var attitude in addedAttitudes)
           {
               attitude.Entity.AdditionalSpecificDate = DateTime.Now;
           }
           return base.SaveChanges();
        }
    }
