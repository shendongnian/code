    private static void Main(string[] args)
    {
        List<User> Users = new List<User>()
        {
            new User {Id = 1, Name = "N1", IsPublic = true},
            new User {Id = 2, Name = "N2", IsPublic = true},
            new User {Id = 3, Name = "N3"}
        };
        var users1 = from u in (from user in Users
            where user.IsPublic
            select new {user.Id, user.Name}).ToList()
            select new User {Id = u.Id, Name = u.Name};
        var users2 =
            Users.Where(x => x.IsPublic)
                .Select(user => new {user.Id, user.Name})
                .ToList()
                .Select(x => new User {Id = x.Id, Name = x.Name});
        Console.ReadLine();
    }
