    var users = new List<User>
    {
        new User { Id = 1,  Name = "Jakob" },
        new User { Id = 2,  Name = "Sam" },
        new User { Id = 3,  Name = "Albert" }
    }
    var filteredUsers = users.Where(user => user.Name == "Jakob");
