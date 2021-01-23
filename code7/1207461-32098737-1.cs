    public List<UserBindings> bindingListHere(string txtSearchUser)
    {
        string getUsers = txtSearchUser;
        int totalrecords = 10;
        ArrayList Users = UserController.GetUsersByUserName(PortalId, getUsers + "%", 0, 10, ref totalrecords, true, IsSuperUser);
        return Users.Cast<UserInfo>().Select(u => new UserBindings { UserID = u.UserID, Username = u.Username, DisplayName = u.DisplayName }).ToList();
    }
