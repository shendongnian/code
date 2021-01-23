    var userList = Membership.GetAllUsers();
    foreach(MembershipUser user in userList)
    {
        string[] rolesArray = Roles.GetRolesForUser(user.UserName); 
        users.Add(new UserViewModel {UserName = user.UserName, UserRole = string.Join(",", rolesArray) });
    }
