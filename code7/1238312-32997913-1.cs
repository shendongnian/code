	public override int SaveChanges()
	{
		try
		{
			DateTime now = DateTime.UtcNow;
			foreach (ObjectStateEntry entry in (this as IObjectContextAdapter).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
			{
				//logger.Info("Setting LastModified on " + entry.Entity.GetType().FullName);
				if (!entry.IsRelationship)
				{
					IHasLastModified lastModified = entry.Entity as IHasLastModified;
					if (lastModified != null)
						lastModified.LastModified = now;
				}
			}
			return base.SaveChanges();
		} 
		catch (DbEntityValidationException valEx)
		{
			List<string> errorList = new List<string>();
			foreach (var error in valEx.EntityValidationErrors)
			{
				foreach (var entry in error.ValidationErrors)
				{
					errorList.Add(entry.PropertyName + ": " + entry.ErrorMessage);
				}
				logger.Error(string.Join(";", errorList));
			}
			throw;
		}
	}
