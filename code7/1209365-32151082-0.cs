    public class YourDbContext : DbContext
    {
		// other code
	
        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            items["is_insert"] = this.Entry(entityEntry.Entity).State == EntityState.Added;
            return base.ValidateEntity(entityEntry, items);
        }
	}
