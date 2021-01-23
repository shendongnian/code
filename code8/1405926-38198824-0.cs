	public static void InvalidateDataGeneric<TEntity>(string foreignKey, int valueFK)
	{
		try
		{
			var key = typeof(TEntity).Name;
			var adapter = (IObjectContextAdapter)EntityModelDataProvider.Database;
			var objectContext = adapter.ObjectContext;
	
			var container = objectContext.MetadataWorkspace.GetEntityContainer(
											objectContext.DefaultContainerName, System.Data.Entity.Core.Metadata.Edm.DataSpace.CSpace);
			var name = container.BaseEntitySets.Where((s) => s.ElementType.Name.Equals(key)).FirstOrDefault().Name;
	
			Func<TEntity, bool> filter = algo => ComparePropertyValue<TEntity>(algo, foreignKey, valueFK);
	
			var query = objectContext.CreateQuery<TEntity>("[" + name + "]").Where(filter);
	
			foreach (var element in query)
			{
				// whatever
			}
	
			objectContext.SaveChanges();
		}
		catch (Exception)
		{
	
			throw;
		}
	}
	private static bool ComparePropertyValue<TEntity>(TEntity entity, string property, object value)
	{
		try
		{
			PropertyInfo propertyInfo = typeof(TEntity).GetProperty(property);
			return propertyInfo.GetValue(entity).Equals(value);
		}
		catch (Exception)
		{
			
			throw;
		}
	}
