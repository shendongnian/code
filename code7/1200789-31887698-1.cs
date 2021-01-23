    Class ReadUserData
    {
      private List<UserData> userdata = new List<UserData>();
    
      for (int j = 0; j < 4 ; j++)
            {
                  userdata.Add( new  
                  UserData(userID[j.ToString()],
                  userProject[j.ToString()], 
                  useraccess[j.ToString()]) );
            }
    
            var firstuser = userdata.FirstOrDefault();
    }
