    foreach(var role in roles)
    {
       var isInRole = await UserManager.IsInRoleAsync(userid, role)
       if(!isInRole)
       {
          await UserManager.AddToRoleAsync(userid, role);
       }
    }
