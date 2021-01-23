	private async Task RevertDummyAsync<TEntity>(
		Entity entity, CancellationToken token) where TEntity : EntityBase
	{
		using (var context = new SomeDbContext())
		{
			ChangeTracker.DetectChanges();
			List<DbEntityEntry<TEntity>> revertEntries = 
				new List<DbEntityEntry<TEntity>>(ChangeTracker.Entries<TEntity>());
	
			foreach (DbEntityEntry entity in revertEntries)
			{
				await entity.ReloadAsync(token);
			}
		}
	}
	
