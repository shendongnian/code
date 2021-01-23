    using System;
	using System.Collections.Generic;
	using SQLite;
	namespace MyApplication
	{
		public static class SqliteExtensions
		{
			public static List<string> Tables (this SQLiteConnection connection)
			{
				const string GET_TABLES_QUERY = "SELECT NAME from sqlite_master";
				List<string> tables = new List<string> ();
				var statement = SQLite3.Prepare2 (connection.Handle, GET_TABLES_QUERY);
				try {
					bool done = false;
					while (!done) {
						SQLite3.Result result = SQLite3.Step (statement);
						if (result == SQLite3.Result.Row) {
							var tableName = SQLite3.ColumnString (statement, 0);
							tables.Add(tableName);
						} else if (result == SQLite3.Result.Done) {
							done = true;
						} else {
							throw SQLiteException.New (result, SQLite3.GetErrmsg (connection.Handle));
						}
					}
				}
				finally {	
					SQLite3.Finalize (statement);
				}
				return tables;
			}
		}
	}
