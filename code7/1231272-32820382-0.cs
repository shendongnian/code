    DataTable tblSelectDeviceProperties = new DataTable();
    using (var daSelectDeviceProperties = new SqlDataAdapter(query, connectionDBTest))
    {
        // no need to open/close the connection with DataAdapter.Fill
        daSelectDeviceProperties.Fill(tblSelectDeviceProperties);   
    }
    if (tblSelectDeviceProperties.Rows.Count == 0)
        Console.WriteLine("No Device Properties found..");
