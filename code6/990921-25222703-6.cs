    public UserInfo GetUserInfo(string username)
    {
        try
        {
            using (UserDataDataContext db = new UserDataDataContext())
            {
                // Get the user's info. 
                var userInfo = (from row in db.mrobUsers
                                where row.Username == username 
                                select new UserInfo
                                {
                                    UserId = row.UserId,
                                    First = row.First
                                    Last = row.Last
                                }).SingleOrDefault();
                return userInfo;
            }
            catch (Exception e)
            {
                return MySerializer.Serialize(false);
            }
        }
    }
