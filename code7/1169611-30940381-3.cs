    public List<User> GetUsers(User admin)
    {
        var adminCompanyIDs = admin.Companys.Select(c => c.ID);
        return Users.Where(user=>user.Companys.Select(c => c.ID).Intersect(adminCompanyIDs).Any()).ToList();        
    }
