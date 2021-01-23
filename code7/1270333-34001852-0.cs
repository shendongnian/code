    if (Context.Entry(updatedFoo).State == EntityState.Detached)
    {
       var oldEntity = Context.Foo.Find(updatedFoo.FooId);
       Context.Entry(oldEntity).CurrentValues.SetValues(updatedSaving);
       Context.Entry(oldEntity).State = EntityState.Modified;
       Context.Entry(oldEntity).Property(x => x.createdUserId).IsModified = false;
       Context.Entry(oldEntity).Property(x => x.createDateTime).IsModified = false;
    }
