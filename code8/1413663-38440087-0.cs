	var allProps = this.ctx.GetType().GetProperties();
	var allDbSets = allProps.Where(pi => pi.PropertyType.IsGenericType && pi.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));
	var allEntities = allDbSets.SelectMany(pi => pi.PropertyType.GetGenericArguments());
	foreach (var entity in allEntities)
	{
		// get collections of entity
		var genericProps = entity.GetProperties().Where(pi => pi.PropertyType.IsGenericType);
		var collections = genericProps.Where(pi => pi.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>));
		if(collections.Any())
		{
			var ent = Activator.CreateInstance(entity);
			foreach (var coll in collections)
			{
				// coll is the PropertyInfo of a ICollection<> object.
				var val = coll.GetValue(ent);
				Assert.IsNotNull(val);
			}
		}
	}
