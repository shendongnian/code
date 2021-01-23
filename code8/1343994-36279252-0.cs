        var usersList = new List<ApplicationUser>();
        foreach (ApplicationUser user in UserManager.Users)
        {
            var roles = await UserManager.GetRolesAsync(user.Id);
            if(roles != null)
            {
                usersList.Add(user);
            }
        }
