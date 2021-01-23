    public List<User> GetUsers(User admin)
    {
        var adminCompanys = admin.Companys;
        return Users.Where(user=>user.Companys.Contains(adminCompanys)).ToList();        
    }
