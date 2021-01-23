    public IEnumerable<UserViewModel> GetUsersBefore73()
    {
        var objRoleController = new RoleController();
        ArrayList UserList = objRoleController
                                .GetUsersByRoleName(PortalSettings.PortalId, "Client");
        var users = from user in UserList.OfType<UserInfo>().ToList<UserInfo>()
                    select new UserViewModel() {
                        Id = user.UserID,
                        DisplayName = user.DisplayName
                    };
        return users;
    }
