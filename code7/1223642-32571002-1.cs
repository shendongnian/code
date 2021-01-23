    try
    {
        var connection = @"your connection string";
        //your command
        var command = "your command";
        var dataAdapter = new System.Data.SqlClient.SqlDataAdapter(command, connection);
        var dataTable = new DataTable();
    
        //Get data
        dataAdapter.Fill(dataTable);
    }
    catch (System.Data.SqlClient.SqlException sqlEx)
    {
        //Use sqlEx.Number to hanlde excception more specific
        //for example if sqlEx.Number -1 => Could Not Connect to Server.
    }
    catch (Exception ex)
    {
    }
