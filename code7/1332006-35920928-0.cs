    var users = UserManager.Users.Select(u => 
        new { 
            Id = u.Id, 
            Email = u.Email, 
            Role = Enum.GetName(typeof(Role),u.Roles.FirstOrDefault().RoleId) });
