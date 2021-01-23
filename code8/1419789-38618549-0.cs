    public partial class YourDataContext
    {
    	protected override System.Data.Entity.Validation.DbEntityValidationResult ValidateEntity(System.Data.Entity.Infrastructure.DbEntityEntry entityEntry, IDictionary<object, object> items)
    	{
    		if (entityEntry.Entity is Boat && entityEntry.State == System.Data.Entity.EntityState.Modified)
    		{
    			Boat modifiedBoat = (Boat)entityEntry.Entity;
    
    			// Set your last modified date and other properties here
    		}
    
    		return base.ValidateEntity(entityEntry, items); 
    	}
    }
