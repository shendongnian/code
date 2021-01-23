	MethodInfo openMethod = typeof(ClassContainingTheAboveMethod).GetMethod("CopyEntitiesToMongo");
	using (MyEntities context = new MyEntities())
	{
		var projects = context.Projects.ToList();
		foreach (var project in projects)
		{
			 var entityType = Type.GetType($"NameSpace.Imp{project.Id}", false);
			 MethodInfo genericMethod = method.MakeGenericMethod(entityType);
			 genericMethod.Invoke(context, _mongoConnect.Database, "Tickets");
		}
	}
