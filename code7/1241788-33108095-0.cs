    var userEntity = new UserEntity() { ID = userUpdate.ID };
    userEntity.SomeProperty = userUpdate.SomeProperty;
    //Tell EF to only update the SomeProperty value:
    context.Entry(userEntity).Property(x => x.SomeProperty).IsModified = true;
    context.SaveChanges();
