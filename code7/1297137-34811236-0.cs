    for (int i = 0; i < lstusers.Count; i++)
    {
        GetUserList usr = new GetUserList();
        usr.UserID = Convert.ToInt32(lstusers[i].userID);
        usr.UserFirstName = Convert.ToString(lstusers[i].forename);
        UsersList.Add(usr);
        //return usr;
    }
