	Database.SetInitializer<ContentDb>(new MigrateDatabaseToLatestVersion<ContentDb, 
                                               Project.Migrations.Configuration>());
	using (var dB = new ContentDb(connectStr))
	{
		dB.Database.Initialize(true);
	}
