    var user = context.Users.Include(u => u.Roles).Where(u => u.USER_ID == entity.USER_ID).FirstOrDefault;
    List<Role> rolesToRemove =
        user.Roles.Where(x => entity.Roles.All(y => y.ROLE_ID != x.ROLE_ID)).ToList();
    //Roles to add
    List<Role> rolesToAdd =
        entity.Roles.Where(x => user.Roles.All(y => y.ROLE_ID != x.ROLE_ID)).ToList();
    
