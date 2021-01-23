    int userRoleList = _homeService.GetUserDetails(identity.User.ToString());
    IList<User> userID = userRoleList.First().ID;
    IList<PartialRole> partialRoleList = _homeService.GetPartialDetails(userID)
    List<int> values = new List<int>(){ 2, 3 };
    if (userRoleList.Any(x => values.Contains(x.RoleID)) && partialRoleList.Any(x => values.Contains(x.RoleID)))
    {
        ViewBag.IsReadonly = true;
    }
    
