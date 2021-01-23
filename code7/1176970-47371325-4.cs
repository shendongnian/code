	using (var context = new MyDbContext())
	{
		var user1 = new User { Name = "Peter", Age = 32 };
		context.Users.AddIfNotExists(user1, u => u.Name);
		
		var user2 = new User { Name = "Joe", Age = 25 };
		context.Users.AddIfNotExists(user2, u => u.Age);
		
		// Adds user1 if there is no user with name "Peter"
		// Adds user2 if there is no user with age 25
		context.SaveChanges();
	}
