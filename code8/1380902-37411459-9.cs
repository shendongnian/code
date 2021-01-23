	MethodInfo openMethod = typeof(ClassContainingTheAboveMethod).GetMethod("CopyEntitiesToMongo");
	using (MyEntities context = new MyEntities())
	{
		var projects = context.Projects.ToList();
		foreach (var project in projects)
		{
			 var entityType = Type.GetType($"NameSpace.Imp{project.Id}", false);
			 MethodInfo boundGenericMethod = openMethod.MakeGenericMethod(entityType);
			 boundGenericMethod.Invoke(this, context, _mongoConnect.Database, "Tickets");
		}
	}
