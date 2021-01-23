    public void RunMigration(string connectionString)
    {
        var migrationConfiguration = new DataAccess.Migrations.Configuration();
    migrationConfiguration.TargetDatabase = new DbConnectionInfo(connectionString);
        var migrator = new System.Data.Entity.Migrations.DbMigrator(migrationConfiguration);
        migrator.Update();
    }
