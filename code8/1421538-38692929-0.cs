	public static void SetPropertiesToModeified<TEntity>(
		this MyContext context, 
		TEntity entity,
		List<string> propertiesNotToUpdate)
	{
		// Get properties to update. Get all properties and
		// exclude the ones you do not want to update.
		List<string> propertiesToUpdate = typeof(TEntity)
			.GetProperties(entity.GetType().Name)				
			.Select(m => m.Name)		
			.Except(propertiesNotToUpdate) // exculde propeties not update
			.ToList();
			
        DbEntityEntry<TEntity> entry = context.Entry(entity);
		propertiesToUpdate.ForEach(
			p => entry.Property(p).IsModified = true);
	}
