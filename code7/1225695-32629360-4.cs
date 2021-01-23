    var result = session.Query<User>()
                        .Where(c => c.UserName == userName)
                        .FetchMany(c => c.Roles)
                        .ThenFetchMany(o => o.Permissions)
                        .FirstOrDefault();
    // and you could use this User object, 
    // but make sure it is not null 
    if (result != null)
    {
       // code...
    }
   
