    GetUserList usr =null;
        List<GetUserList> UsersList = new List<GetUserList>();
        List<users> lstusers= usersBase.GetUsersListByOrgId(OrgId, null);
        try
        {
            if (lstusers.Count > 0)
            {
               // ;
                for (int i = 0; i < lstusers.Count; i++)
                {
                    usr= new GetUserList();
                    usr.Message = "Success"  
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
