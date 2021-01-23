    public void InitializeDatabase(DataAccessManager context)
	{
		if (!context.Database.Exists() || !context.Database.CompatibleWithModel(false))
		{
			var configuration = new DbMigrationsConfiguration();
			var migrator = new DbMigrator(configuration);
			migrator.Configuration.TargetDatabase = new DbConnectionInfo(context.Database.Connection.ConnectionString, "System.Data.SqlClient");
			var migrations = migrator.GetPendingMigrations();
			if (migrations.Any())
			{
				var scriptor = new MigratorScriptingDecorator(migrator);
				var script = scriptor.ScriptUpdate(null, migrations.Last());
				if (!string.IsNullOrEmpty(script))
				{
					context.Database.ExecuteSqlCommand(script);
				}
			}
		}
	}
