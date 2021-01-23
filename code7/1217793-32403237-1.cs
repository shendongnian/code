    public void Update(UserModel userModel)
    {
        Mapper.Map(userModel, updatingUser);
        db.Entry(updatingUser).State = EntityState.Modified;
        db.SaveChanges();
    }
