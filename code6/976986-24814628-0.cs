    vehicleViewModel Vehicle = null;
    using (var db = new SQLite.SQLiteConnection(App.DBPath))
    {
      ...
    
      Vehicle = new vehicleViewModel();
      ...
    }
