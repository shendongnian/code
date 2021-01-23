    [Test]
    public void Test()
    {
    	LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
    	using(var db = new TestDb())
    	{
    		var directoriesWithFiles = db.Directories.LoadWith(d => d.Files).ToList();
    	}
    }
    
    [Test]
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
