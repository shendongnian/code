    MyContext db = new MyContext();
    MyClass sampleModel = new MyClass();
    sampleModel.IdMyClass = "1d1ba1f2-8c08-c334-5486-08d16fecc6e3"; //GUID
    sampleModel.ModificationDate = DateTime.Now;
    sampleModel.Name=string.Empty; //should not be needed
    db.MyClass.Attach(sampleModel);
    var entry=db.Entry(sampleModel);
    entry.State = EntityState.Modified;
    var excluded = new string[] { "IdMyClass","Name" };
    foreach (var name in excluded)
    {
       entry.Property(name).IsModified = false;
    }
    db.SaveChanges();
    
    
    
