    	    var migrationConfig = new MyApp.Data.Migrations.Configuration
            {
                TargetDatabase = new DbConnectionInfo(tenantProfile.ConnectionString, "MySql.Data.MySqlClient")
            };
            var migrator = new DbMigrator(migrationConfig);
            migrator.Update();
