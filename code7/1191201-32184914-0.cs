                OleDbConnection accCon = new OleDbConnection();
                OdbcCommand mySQLCon = new OdbcCommand();
                try
                {
                    //connect to mysql
                    Connect();
                    mySQLCon.Connection = connection;
    
                    //connect to access
                    accCon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                                              @"Data source= " + pathToAccess;
                    accCon.Open();
                    var cnt = 0;
    
                    while (cnt < 5)
                    {
                        if (accCon.State == ConnectionState.Open)
                            break;
                        cnt++;
                        System.Threading.Thread.Sleep(50);
                    }
    
                    if (cnt == 5)
                    {
                        ToolBox.logThis("Connection to Access DB did not open. Exit Process");
                        return;
                    }
                }
                catch (Exception e)
                {
                    ToolBox.logThis("Faild to Open connections. msg -> " + e.Message + "\\n" + e.StackTrace);
                }
    //AMK: transaction starts here
                var transaction = accCon.BeginTransaction();
                OleDbCommand accCmn = new OleDbCommand();
                
                accCmn.Connection = accCon;
                accCmn.Transaction = transaction;
    //access insert query structure
                var insertAccessQuery = "INSERT INTO {0} values({1});";
    // key = > tbl name in access, value = > mysql query to b executed
                foreach (var table in tblNQuery)
                {
                    try
                    {
                        mySQLCon.CommandText = table.Value;
                        //executed mysql query                        
                        using (var dataReader = mySQLCon.ExecuteReader())
                        {
                            //variable to hold row data
                            var rowData = new object[dataReader.FieldCount];
                            var parameters = "";
                            //read the result set from mysql query
                            while (dataReader.Read())
                            {
                                //fill rowData with the row values
                                dataReader.GetValues(rowData);
                                //build the parameters for insert query
                                for (var i = 0; i < dataReader.FieldCount; i++)
                                    parameters += "'" + rowData[i] + "',";
    
                                parameters = parameters.TrimEnd(',');
                                //insert to access
                                accCmn.CommandText = string.Format(insertAccessQuery, table.Key, parameters);
                                try
                                {
                                    accCmn.ExecuteNonQuery();
                                }
                                catch (Exception exc)
                                {
                                    ToolBox.logThis("Faild to insert to access db. msg -> " + exc.Message +
                                                    "\\n\\tInsert query -> " + accCmn.CommandText);
                                }
                                parameters = "";
                            }
                        }
    //AMK: transaction commits here if every thing is going well
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        ToolBox.logThis("Faild to populate access db. msg -> " + e.Message + "\\n" + e.StackTrace);
    //AMK: transaction rollback here if there is a problem
                        transaction.Rollback();
                    }
                }
                Disconnect();
                accCmn.Dispose();
                accCon.Close();
