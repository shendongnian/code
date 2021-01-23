    var model = new MyTable { Id = Id, UpdateTime = DateTime.UtcNow , Title = "EveryThing" };
    var dbSet = this.dbContext.Set<MyTable>();
    dbSet.Attach(model);                
    entry = this.dbContext.Entry(model);
    entry.Property("UpdateTime").IsModified = true;
    this.dbContext.SaveChanges();
