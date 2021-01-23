    Class ReadUserData
    {
      private List<UserData> userdata = new List<UserData>();// create empty list
      for (int j = 0; j < 4 ; j++)
            {
                userdata.Add(new  
                  UserData(userID[j.ToString()],
                  userProject[j.ToString()], 
                  useraccess[j.ToString()])); // add objects to the list at each iteration
            }
            var firstuser = userdata.FirstOrDefault();
    }
