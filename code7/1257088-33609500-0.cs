    int SomeFunction()
    {
      using (var db = new Database())
        return SomeFunction(db);
    }
    int SomeFunction(Database db)
    {
      return db.Users.Count();
    }
