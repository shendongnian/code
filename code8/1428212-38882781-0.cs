    User user;
    var data = from u in context.DbContext.Users select u;
    
    user = data.FirstOrDefault();
    // load UserRoles and UserRoles.Role
    context.Entry(user)
        .Collection(u => u.UserRoles)
        .Query()
        .Include(ur => ur.Role)
        .Where(ur => ur.EnvironmentId == environmentId)
        .Load()
    ;
