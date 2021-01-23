    public static void RunSQLiteTransaction(string myConnString) { 
        using (SQLiteConnection sqConnection = new SQLiteConnection(myConnString)) { 
            sqConnection.Open(); 
            // Start a local transaction 
            SQLiteTransaction myTrans = sqConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted); 
            SQLiteCommand sqCommand = sqConnection.CreateCommand(); 
            try { 
                sqCommand.CommandText = "INSERT INTO Dept(DeptNo, DName) Values(52, 'DEVELOPMENT')"; 
                sqCommand.ExecuteNonQuery(); 
                sqCommand.CommandText = "INSERT INTO Dept(DeptNo, DName) Values(62, 'PRODUCTION')"; 
                sqCommand.ExecuteNonQuery(); 
                myTrans.Commit(); 
                Console.WriteLine("Both records are written to database."); 
            } 
            catch (Exception e) { 
                myTrans.Rollback(); 
                Console.WriteLine(e.ToString()); 
                Console.WriteLine("Neither record was written to database."); 
            } 
            finally { 
                sqCommand.Dispose(); 
                myTrans.Dispose(); 
            } 
        } 
    } 
