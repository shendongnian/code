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
        // UNTESTED CODE - but it should be close. 
        GridView gv = new GridView(); // create gridview
        gv.DataSource = dt; // Set the DataTable as the DataSource for the GridView
        gv.DataBind(); // Bind the Data to the GridView
        StringWriter sWriter = new StringWriter(); //stringwriter needed for html writer
        HtmlTextWriter htWriter = new HtmlTextWriter(sWriter); // create HthmWriter
        gv.RenderControl(htWriter); //render the gridview in the htmlwriter
        htWriter.Write(true); // write the html writer to the output stream
        
    }
    
    catch (Exception ex)
    {
        MessageBox.Show("Can not open connection ! ");
    }
