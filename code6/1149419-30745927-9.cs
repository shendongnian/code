    // Make sure that the user has the INSERT privilege for the OrderHistory table.
    NpgsqlConnection connection = new NpgsqlConnection("PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;COMPATIBLE=2.2.4.3;DATABASE=test;HOST=127.0.0.1;PASSWORD=test;USER ID=test");
    
    connection.Open();
    
    DataSet dataSet = new DataSet();
    
    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter("select * from OrderHistory where OrderId=-1", connection);
    dataAdapter.InsertCommand = new NpgsqlCommand("insert into OrderHistory(OrderId, TotalAmount) " +
    						" values (:a, :b)", connection);
    dataAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("a", NpgsqlDbType.Bigint));
    dataAdapter.InsertCommand.Parameters.Add(new NpgsqlParameter("b", NpgsqlDbType.Bigint));
    dataAdapter.InsertCommand.Parameters[0].Direction = ParameterDirection.Input;
    dataAdapter.InsertCommand.Parameters[1].Direction = ParameterDirection.Input;
    dataAdapter.InsertCommand.Parameters[0].SourceColumn = "OrderId";
    dataAdapter.InsertCommand.Parameters[1].SourceColumn = "TotalAmount";
    
    dataAdapter.Fill(dataSet);
    
    DataTable newOrders = dataSet.Tables[0];
    DataRow newOrder = newOrders.NewRow();
    newOrder["OrderId"] = 20;
    newOrder["TotalAmount"] = 20.0;
    
    newOrders.Rows.Add(newOrder);
    DataSet ds2 = dataSet.GetChanges();
    dataAdapter.Update(ds2);
    dataSet.Merge(ds2);
    dataSet.AcceptChanges();
    
    connection.Close();
