    protected override void Seed(DatabaseContext context)
    {
        Role role = new Role
        {
            RoleName = "Admin"
        };
        Role role2 = new Role
        {
            RoleName = "HR"
        };
        Role role3 = new Role
        {
            RoleName = "Marketing"
        };
        var roles= new List<Role> { role, role2,role3 };
        roles.ForEach(i => context.Roles.AddOrUpdate(i));
        context.SaveChanges();
        User user= new User
        { 
            Email = "abc.blog@gmail.com",
            Username = "abc123",
            HashedPassword = "XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
            Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
            IsLocked = false,
            DateCreated = DateTime.Now,
            Roles= new List<Role> { role,role2 }
        };
        User user2 = new User
        { 
            Email = "def.blog@gmail.com",
            Username = "def123",
            HashedPassword = "XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
            Salt = "mNKLRbEFCH8y1xIyTXP4qA==",
            IsLocked = false,
            DateCreated = DateTime.Now,
            Roles= new List<Role> { role3 }
        };
        
        var users= new List<User> { user, user2};
        users.ForEach(a => context.Users.AddOrUpdate(a));
        context.SaveChanges();
    }
