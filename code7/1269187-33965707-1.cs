    List<User> _allUsers = new List<User>();
    _allUsers.Add(/* user object */); //populate the list with Users using .Add()
    foreach (var user in _allUsers)
    {
        if(user.userName == someInputVariable && user.passWord == someOtherInputVariable)
        {
            ...
        }
    }
