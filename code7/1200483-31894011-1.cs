    public static UserInfo GetUserByName(int portalId, string username)
    {
        var foundUsers = UserController.Instance.GetUsersBasicSearch(portalId, 0, 10, "UserID", true, "UserName", username);
        if (foundUsers.Any())
        {
            return foundUsers.FirstOrDefault();
        }
        else
        {
            return null;
        }
    }
