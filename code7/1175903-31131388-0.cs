    string id = string.Empty;
    User user = Context.Users.FirstOrDefault(x => x.UserName == username);
    if(user != null)
    {
        id=user.Id.ToString(); //if id is already a string no need for ToString()
    }
