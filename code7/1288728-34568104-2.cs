    public IEnumerable<UserViewModel> GetUsersAfter73()
    {
        IList<UserInfo> UserList = RoleController
                            .Instance
                            .GetUsersByRole(PortalSettings.PortalId, "Client");
        var users = from user in UserList
                    select new UserViewModel() {
                        Id = user.UserID,
                        DisplayName = user.DisplayName
                    };
        return users;
    }
