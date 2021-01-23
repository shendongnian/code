    var db=new DatabaseContext();
    var entityToUpdate = new Person();
    var entry=db.Entry(entityToUpdate);
    entry.State = EntityState.Modified;
    var excluded = new string[] { "BirthDate", "Name", "FooBar" };
    foreach (var name in excluded)
    {
       entry.Property(name).IsModified = false;
    }
