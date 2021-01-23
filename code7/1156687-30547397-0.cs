    using(var db=new YourContext())
    {
        var res= db.UserRoles.GroupBy(ur=>ur.userId)
                             .Select(g=>new UserRoleDto()
                                        { 
                                          userId = g.Key,
                                          roleIds = g.Select(us=>us.roleId).ToList()
                                        } 
                                    ).ToList();
    }
