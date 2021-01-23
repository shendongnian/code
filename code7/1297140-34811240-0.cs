    try
    {
        if (lstusers.Count > 0)
        {
            //create a new instance of user here
            usr = new GetUserList();
            usr.Message = "Success";
            for (int i = 0; i < lstusers.Count; i++)
            {
                usr.UserID = Convert.ToInt32(lstusers[i].userID);
                usr.UserFirstName = Convert.ToString(lstusers[i].forename);
                UsersList.Add(usr);
                //return usr;
            }
        }
        else
        {
            usr.Message = "Failed";
        }
        return UsersList;
    }
    catch (Exception e)
    {
        throw e;
    }
