    DataTable dt = new DataTable();
    try
    {
        sCnn.Open();
        sCmd = new SqlCommand(sql, sCnn);
        SqlDataReader sReader = sCmd.ExecuteReader();
    
        sReader.Read();
        sReader.NextResult(); //move to next table
    
        sReader.Read();
        sReader.NextResult(); //move to next table
     
        dt.Load(sReader); // Convert your data reader to a DataTable
        
        sqlReader.Close();
        sqlCmd.Dispose();
        sqlCnn.Close();
        gv.DataSource = dt; // Set the DataTable as the DataSource for the GridView
        gv.DataBind(); // Bind the Data to the GridView
    }
    
    catch (Exception ex)
    {
        MessageBox.Show("Can not open connection ! ");
    }
