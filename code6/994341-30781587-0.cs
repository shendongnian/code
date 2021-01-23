    string ConnectionString = "server=xxx;Uid=xxx;Pwd=xxx;Database=xxx";
    string Command = "INSERT INTO User2 (FirstName, LastName ) VALUES (@FirstName, @LastName);";
     using (var mConnection = new MySqlConnection(ConnectionString))
         {
             mConnection.Open();
             MySqlTransaction transaction = mConnection.BeginTransaction();
            //Obtain a dataset, obviously a "select *" is not the best way...
            var mySqlDataAdapterSelect = new MySqlDataAdapter("select * from User2", mConnection);
            var ds = new DataSet();
            mySqlDataAdapterSelect.Fill(ds, "User2");
            var mySqlDataAdapter = new MySqlDataAdapter();
            mySqlDataAdapter.InsertCommand = new MySqlCommand(Command, mConnection);
            mySqlDataAdapter.InsertCommand.Parameters.Add("@FirstName", MySqlDbType.VarChar, 32, "FirstName");
            mySqlDataAdapter.InsertCommand.Parameters.Add("@LastName", MySqlDbType.VarChar, 32, "LastName");
            mySqlDataAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 50000; i++)
            {
                DataRow row = ds.Tables["User2"].NewRow();
                row["FirstName"] = "1234";
                row["LastName"] = "1234";
                ds.Tables["User2"].Rows.Add(row);
            }
             mySqlDataAdapter.UpdateBatchSize = 100;
             mySqlDataAdapter.Update(ds, "User2");
             transaction.Commit();
             stopwatch.Stop();
             Debug.WriteLine(" inserts took " + stopwatch.ElapsedMilliseconds + "ms");
        }
    }
