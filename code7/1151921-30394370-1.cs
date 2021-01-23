    try
    {
        objConnect = new DBconnection();
        conStringAUTH = Properties.Settings.Default.authConnectionString;
        objConnect.connection_string = conStringAUTH;
        objConnect.Sql = "QUERY GOES HERE";
        ds = objConnect.GetConnection;
        // Data manipulation
        maxRows = ds.Tables[0].Rows.Count;
        if (maxRows == 0)
        {
            // Your query returned no values
        }
    }
    catch (Exception err)
    {
        MessageBox.Show(err.Message);
    }
