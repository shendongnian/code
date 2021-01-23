	Database.SetInitializer(new DropCreateDatabaseAlways<ApsContext>());
	using (MyContext context = new MyContext())
	{
		context.Database.Delete();
	}
