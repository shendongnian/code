    [Test] // 1 query to load directories + separate queries to load files for each directory
    public void Test()
    {
    	LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
    	using(var db = new TestDb())
    	{
    		var directoriesWithFiles = db.Directories.LoadWith(d => d.Files).ToList();
    	}
    }
    
    [Test] // same as above, but manually
    public void Test2()
    {
    	using(var db = new TestDb())
    	{
    		var directories = db.Directories.ToList();
    
    		foreach (var d in directories)
    		{
    			d.Files = db.Files.Where(f => f.DirectoryID == d.ID).ToList();
    		}
    	}
    }
    [Test] // if you want only 2 queries to the database
    public void Test3()
    {
    	using (var db = new TestDb())
    	{
    		var dict = new Dictionary<int, List<File>>();
    
    		foreach(var file in db.Files)
    		{
    			if(!dict.ContainsKey(file.DirectoryID))
    				dict.Add(file.DirectoryID, new List<File> { file });
    			else
    				dict[file.DirectoryID].Add(file);
    		}
    
    		var directories = db.Directories.ToList();
    
    		foreach (var d in directories)
    		{
    			List<File> files;
    			d.Files = dict.TryGetValue(d.ID, out files) ? files : new List<File>();
    		}
    	}
    }
