    List<UsersTabPage> GetFirstOne()
    {
        using (MCMDataContext db = new MCMDataContext())
        {
            MCM.User user = new MCM.User();
            var firstone = (from oneUser in db.Users
                      where oneUser.ID == user.ID
                      select oneUser);
            return firstone.ToList();
        }
    }
