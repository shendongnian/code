    public class ApplicationDbContext : DbContext
    {
        public override int SaveChanges()
        {
            
            var ModifiedDeletedEntities = ChangeTracker.Entries()
                  .Where(E => E.State == EntityState.Deleted ||
                              E.State == EntityState.Modified).ToList();
            foreach (IEntity entity in ModifiedDeletedEntities)
            {
                if (entity.UserId != GetCurrentUserId())
                {
                    throw new Exception("Access Denied!");
                }
            }
            var AddedEntities = ChangeTracker.Entries()
                   .Where(E => E.State == EntityState.Added).ToList();
            foreach (IEntity entity in AddedEntities)
            {
                entity.UserId = GetCurrentUserId();
            }
                return base.SaveChanges();
        }
