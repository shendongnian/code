    if (entry.Entity is IRevisable)
    {
         var myEntity = entry.Entity as IRevisable;
         ctx.LoadProperty(myEntity.RevisedBy, x => x.Roles);
         if (myEntity.RevisedBy.Roles.Find(x => x.RoleName == "ADMIN") == null)    return;
    }
