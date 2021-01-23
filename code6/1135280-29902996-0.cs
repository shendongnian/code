    public partial class MyDbContext : DbContext
    {
		public override int SaveChanges()
		{
			IEnumerable<ObjectStateEntry> objectStateEntries;
			ObjectContext context = ((IObjectContextAdapter)this).ObjectContext;
			//Find all Entities that are Added/Modified that inherit from BaseDataItem
			objectStateEntries =
					from item in context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
					where (item.IsRelationship == false) &&
								(item.Entity != null) &&
								(typeof(BaseDataItem).IsAssignableFrom(item.Entity.GetType()))
					select item;
			DateTime currentTime = DateTime.Now;
			foreach (ObjectStateEntry entry in objectStateEntries)
			{
				BaseDataItem entityBase = entry.Entity as BaseDataItem;
				if (entry.State == EntityState.Added)
					entityBase.CreatedDate = currentTime;
				entityBase.ModifiedDate = currentTime;
			}
			return base.SaveChanges();
		}
    }
