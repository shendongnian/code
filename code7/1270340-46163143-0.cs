    [TestMethod]
    public void GenerateTestMigration()
    {
        var config = new MyDbMigrationsConfiguration();
        var scaffolder = new MigrationScaffolder(config);
        var pendingMigration = scaffolder.Scaffold("TestMigration");
        Trace.WriteLine(pendingMigration.UserCode);
    }
	
