    Expression<Func<UserRoleInApplication, bool>> predicate = x => true;
    if(exludeRoleNames != null)
    {
        foreach(string exl in exludeRoleNames)
        {    
            string temp = exl;
            predicate = predicate.Or(x=>x.UserRole.RoleName == temp);
        }
    }
