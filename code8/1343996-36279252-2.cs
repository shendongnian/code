        var usersList = new List<ApplicationUser>();
        foreach (ApplicationUser user in UserManager.Users)
        {
            var roles = await UserManager.GetRolesAsync(user.Id);
            if(roles.contains("Admin"))
            {
                usersList.Add(user);
            }
        }
