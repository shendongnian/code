    List<UsersTabPage> GetFirstOne()
    {
        using (MCMDataContext db = new MCMDataContext())
        {
            MCM.User user = new MCM.User();
            return (from oneUser in db.Users
                      where oneUser.ID == user.ID
                      select oneUser).ToList();
        }
    }
