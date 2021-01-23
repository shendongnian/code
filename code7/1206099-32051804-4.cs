    var users = new List<User>();
    
    users.Add(new User { Id = 1, Name = "John" });
    users.Add(new User { Id = 1, Name = "Lorem" });
    users.Add(new User { Id = 2, Name = "Smith" });
    
    users.Distinct(new UserEqualityComparer());
