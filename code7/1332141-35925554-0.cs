    1st Example:
        User:
           UserId Int
           FirstName String
           LastName string
           DepotId Int
           DepartmentId Int
           RoleId Int
    
    2nd Example:
        UsersInRole
            UserId Int
            RoleId Int
Now once you GET a user, you can bring back the RoleId:
    public ActionResult List()
    {
        // Get Roles
        ViewBag.Roles = (from role in dbContext.Roles
                         select new SelectListItem 
                         {
                             Text = role.RoleName,
                             Value = role.RoleId
                          });
        // Get Users
        IEnumerable<User> users = (from user in dbContext.Users
                                   select new User 
                                   {
                                      UserId = user.UserId,
                                      FirstName = user.FirstName,
                                      LastName = user.LastName,
                                      DepotId = user.DepotId,
                                      DepartmentId = user.DepartmentId,
                                      RoleId = user.RoleId,
                                      // OR
                                      // RoleId = dbContext.Roles.Where(r => r.UserId == user.UserId).First().RoleId
                                      //
                                   });
          return users;
    }
