    public List<CustomClass> ReadUsers()
    {
            var users = db.Users.Select(u => new CustomClass{ UserName = u.UserName, IsDisable = u.IsDisable, FullName = u.FullName, Description u.Descriprion }).ToList();
            return users;
    }
