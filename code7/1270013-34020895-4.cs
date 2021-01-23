    public SQLite.SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "/Users/my_user_name_on_imac_machine/dev_projects/OpenSqlLiteTest/OpenSqlLiteTest/sqlite-test.db3";
			var conn = new SQLite.SQLiteConnection(sqliteFilename);
			// Return the database connection
			return conn;
		}
		public int getCntFriend()
		{
			int numOfFriend = 0;
			SQLite.SQLiteConnection sqliteConn = null;
			SQLite.SQLiteCommand sqliteCommand = null;
			// Construct SQL connection
			try{
				sqliteConn = GetConnection ();
			}catch(Exception ex){
				Console.WriteLine ("SqliteConnection exception: " + ex.Message);
			}
			if(sqliteConn != null){
				using(sqliteConn){
					sqliteCommand = new SQLite.SQLiteCommand (sqliteConn);
					sqliteCommand.CommandText = "SELECT count(*) FROM 'users';";
					try{
						numOfFriend = sqliteCommand.ExecuteScalar<int>();
					}catch(Exception exCmd){
						Console.WriteLine ("Exception on Command execution: " + exCmd.Message);
					}
				}	
			}
			return numOfFriend;
		}
