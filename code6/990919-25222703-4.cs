    // You should change the return type of your method, if you want to return an array of
    // strings.
    public string[] GetUserInfo(string username)
    {
        try
        {
            using (UserDataDataContext db = new UserDataDataContext())
            {
                // Get the user's info. 
                var userInfo = (from row in db.mrobUsers
                                where row.Username == username 
                                select row).SingleOrDefault();
                // If the user's info found return the corresponding values.
                if(userInfo!=null)
                {
                    var t = typeof(userInfo);
                    List<string> values = new List<string>();
                    foreach(var prop in t.GetProperties())
                    {
                        values.Add(prop.GetValue(userInfo, null);
                    }
                    return values.ToArray();
                }
                else // the user's info not found and return an empty array. 
                {
                    return new string[] { };
                }
                   // I've debugged up to here, and my user name is passed into this
                }
            }
            catch (Exception e)
            {
                return MySerializer.Serialize(false);
            }
        }
    }
