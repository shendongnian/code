    public void UpdateUser(int idOfUser)
    {
      if(!TestValid(idOfUser))
        throw new ArgumentException("idOfUser");
      var user = GetUserById(idOfUser);
      // Do stuff with user
    }
    public void UpdateUser(int idOfUser)
    {
      var user = GetUserById(idOfUser);
      if(user == null)
        throw new ArgumentException("idOfUser");
      // Do stuff with user
    }
