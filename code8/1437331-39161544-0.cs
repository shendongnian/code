    // assume your query like "SELECT DISTINCT I1 FROM NewItems"
    // resulting single column with multiple distinct value rows
    rdItems = itemsCmd.ExecuteReader();
    
    DataTable dt = new DataTable();
    dt.Load(rdItems); // load DataReader contents to a DataTable, resulting an empty DataTable if no row exists
    
    // check if datatable is not empty as substitute of SqlDataReader.HasRows property
    if (dt.Rows.Count > 0)
    {
        foreach (DataRow row in dt.Rows)
        {
            // get row data
            itemType = row.Field<String>(0);
        }
    }
