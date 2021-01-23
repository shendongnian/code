    ((IObjectContextAdapter)yourDbContext).ObjectContext.ObjectMaterialized += (sender, e) =>
    	{
    		var entityAsMaster = e.Entity as Master;
    		if (entityAsMaster != null)
    		{
    			entityAsMaster.HasDetails = this.context
    				.Entry(entityAsMaster)
    				.Collection(z => z.Details)
    				.Query()
    				.Any();
    		}
    	};
