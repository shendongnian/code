    using (var context = GetContext())
    {
      var userEntity = new UserEntity() { ID = userUpdate.ID };
      context.Users.Attach(userEntity);
      context.Entry(userEntity).CurrentValues.SetValues(userUpdate);
      // Disable entity validation
      context.Configuration.ValidateOnSaveEnabled = false;
      context.SaveChanges();
    }
