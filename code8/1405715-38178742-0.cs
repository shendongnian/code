		var propertyInfo = typeof(Entity).GetProperties().First(p => p.Name == "Id");		
		var paramExpr = Expression.Parameter(typeof(Entity));
		var propertyAccessExpr = Expression.MakeMemberAccess(paramExpr, propertyInfo);
        var guidExpr = Expression.Constant(Guid.Parse("38EB4D06-E50B-4C7A-80FF-A6350051682A"));
		var body = Expression.Equal(propertyAccessExpr, guidExpr);
		var lambda = Expression.Lambda<Func<Entity, bool>>(body, paramExpr);
		
		Console.WriteLine(lambda); // Param_0 => (Param_0.Id == 38eb4d06-e50b-4c7a-80ff-a6350051682a)
