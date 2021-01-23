    public void Update(UserModel userModel)
    {
        var user = db.Users.Find(userModel.UserId);
        Mapper.Map(userModel, user);
        db.SaveChanges();
    }
