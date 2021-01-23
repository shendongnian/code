        public override int SaveChanges()
        {
			this.ObjectContext.DetectChanges();
			// Get all the new and updated objects
			var objectsToValidate =
			ChangeTracker.Entries().Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).
			Select(e => e.Entity);
			// Check each object for errors
			foreach (var obj in objectsToValidate)
			{
				if (obj is IDataErrorInfo)
				{
					// Check each property
					foreach (var property in obj.GetType().GetProperties())
					{
						var columnError = (obj as IDataErrorInfo)[property.Name];
						if (columnError != null) {
                        //Handle your validation errors
                        throw new DbEntityValidationException(columnError); }
					}
				}
			}
		    return base.SaveChanges();
		}
