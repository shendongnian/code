    public sealed class DatabaseMigrationService : IMigrationService
    	{
    		private ISQLite sqlite;
    		private ISettingsService settings;
    		private List<IMigration> migrations;
    
    		public DatabaseMigrationService(ISQLite sqlite, ISettingsService settings)
    		{
    			this.sqlite = sqlite;
    			this.settings = settings;
    
    			SetupMigrations();
    		}
    
    		private void SetupMigrations()
    		{
    			migrations = new List<IMigration> {
    				new Migration1(),
    				new Migration2(),
    				new Migration3(),
    				new Migration4(),
    				new Migration5(),
    				new Migration6()
    			};
    		}
    
    		public async Task RunMigrations()
    		{
    			// TODO run migrations in a transaction, otherwise, if and error is found, the app could stay in a horrible state
    
    			if (settings.DatabaseVersion < migrations.Count)
    			{
    				var connection = new SQLiteAsyncConnection(() => sqlite.GetConnectionWithLock());
    
    				while (settings.DatabaseVersion < migrations.Count)
    				{
    					var nextVersion = settings.DatabaseVersion + 1;
    					var success = await migrations[nextVersion - 1].UseConnection(connection).Run();
    
    					if (success)
    					{
    						settings.DatabaseVersion = nextVersion;
    					}
    					else
    					{
    						MvxTrace.Error("Migration process stopped after error found at {0}", migrations[nextVersion - 1].GetType().Name);
    						break;
    					}
    				}
    			}
    		}
    	}
