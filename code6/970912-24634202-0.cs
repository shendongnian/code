    List<Data> results = new List<Data>();
    
    using (var conn= new SQLite.SQLiteConnection(_pathToDatabase)){
        var query = conn.Table<Person>();
        foreach (var names in query) {
          var item = new Data();
          item.FirstName = names.FirstName;
          item.LastName = names.LastName;
          item.ID = name.ID;
    
          results.Add(item);
        }
    }
