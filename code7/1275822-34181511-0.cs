    public List<ToDoTasks> GetData()
    {
    	string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "database.db3");
    	var db = new SQLiteConnection(dbPath);
        return db.Table<ToDoTasks>().ToList();
    }
    
