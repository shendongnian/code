    namespace ModelApp_MVC.Models
    {
    	public partial class Entities : DbContext
    	{
    		public override int SaveChanges()
    		{
    			//Do custom code
    			// throw new Exception("override DbContext>SaveChanges working");
    			// this.SaveChanges();
    
    
    			var modifiedEntities = ChangeTracker.Entries()
    				.Where(p => p.State == EntityState.Modified).ToList();
    			var now = DateTime.UtcNow;
    
    			foreach (var change in modifiedEntities)
    			{
    				var entityName = change.Entity.GetType().Name;
    				var primaryKey = GetPrimaryKeyValue(change);
    
    				foreach (var prop in change.OriginalValues.PropertyNames)
    				{
    					var originalValue = change.OriginalValues[prop].ToString();
    					var currentValue = change.CurrentValues[prop].ToString();
    					if (originalValue != currentValue) //Only create a log if the value changes
    					{
    						ChangeLog log = new ChangeLog()
                    {
                        EntityName = entityName,
                        PrimaryKeyValue = primaryKey.ToString(),
                        PropertyName = prop,
                        OldValue = originalValue,
                        NewValue = currentValue,
                        DateChanged = now
                    };
                    ChangeLogs.Add(log);
    					}
    				}
    			}
    			return base.SaveChanges();
    		}
    
    		object GetPrimaryKeyValue(DbEntityEntry entry)
    		{
    			var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
    			return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
    		}
    	}
    }
