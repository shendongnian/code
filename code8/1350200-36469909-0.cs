          public bool connectToSQLiteCreateDB(string DBName)
        {
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=" + DBName + ".db;Version=3;New=True;Compress=True;");
            try
            {
                // open the connection:
                sqlite_conn.Open();
                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();
                // Let the SQLiteCommand object know our SQL-Query:
                // Create Entilement Table 
                sqlite_cmd.CommandText = "CREATE TABLE entitlement (" +
          "commodity_name_en 	character varying," +
          "commodity_name_ll 	character varying," +
          );";
                // Now lets execute the SQL ;D
                sqlite_cmd.ExecuteNonQuery();
                sqlite_conn.Close();
                return true;
            }catch(Exception ex)
            {
                 var err=ex.Message;
                 return false;
            }
                   }
         public void connectToSQLiteInsertIntoDB(string DBName)
        {
            sqlite_conn = new SQLiteConnection("Data Source=" + DBName + ".db;Version=3;New=False;");
            // open the connection:
            sqlite_conn.Open();
            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            //// Lets insert something into our new table:
            //sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (1, 'Test Text 1');";
            //// And execute this again ;D
            //sqlite_cmd.ExecuteNonQuery();
            //// ...and inserting another line:
            //sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (2, 'Test Text 2');";
            //// And execute this again ;D
            //sqlite_cmd.ExecuteNonQuery();
            //// But how do we read something out of our table ?
            //// First lets build a SQL-Query again:
            //sqlite_cmd.CommandText = "SELECT * FROM test";
            //// Now the SQLiteCommand object can give us a DataReader-Object:
            //sqlite_datareader = sqlite_cmd.ExecuteReader();
            //// The SQLiteDataReader allows us to run through the result lines:
            //while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            //{
            //    // Print out the content of the text field:
            //    //System.Console.WriteLine(sqlite_datareader["text"]);
            //    string op = sqlite_datareader.GetString(0);
            //}
        }
