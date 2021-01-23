    [TestMethod]
    public void Test_TotalFileCount1()
    {
        ApplicationDbContext context = new ApplicationDbContext();
    
        // Create session with no files
        var session = context.Sessions.Create();
    	session.Name = "Session1";	
    	
        context.Sessions.Add(session);
        context.SaveChanges();
    
        // This line blows up because session.Files == null
        Assert.AreEqual(0, session.Files.Count);
    }
    [TestMethod]
    public void Test_TotalFileCount2()
    {
        ApplicationDbContext context = new ApplicationDbContext();
    
        // Create session
        var session = context.Sessions.Create();
    	session.Name = "Session2";
    	session.Files = new List<File>()
    	{
    		new File() { Name = "File1" }
    	};
    		
        context.Sessions.Add(session);
        context.SaveChanges();
    
    
        // This test passes because session.Files is a
        // collection of one file
        Assert.AreEqual(1, session.Files.Count);
    }
