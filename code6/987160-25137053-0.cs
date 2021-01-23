         if (ConfigurationManager.AppSettings["EnvironmentIn"] == "development")
             {
                        SetDatabaseInitializer(new DropCreateAndMigrateDatabaseInitializer<SchedulingReadContext>());
             }
         else
             {
                       SetDatabaseInitializer(new MigrateDatabaseToLatestVersion<SchedulingReadContext, Configuration>());
             }
  
