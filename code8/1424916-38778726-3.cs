    DataTable dtMaster = LoadXMLToDT(@"C:\Temp\dtsample.xml");
    // just a debug monitor
    var changes = dtMaster.GetChanges();
    
    string SQL = "SELECT * FROM Destination";
    using (MySqlConnection dbCon = new MySqlConnection(MySQLOtherDB))
    {
        dtSample = new DataTable();
        daSample = new MySqlDataAdapter(SQL, dbCon);
    
        MySqlCommandBuilder cb = new MySqlCommandBuilder(daSample);
        daSample.UpdateCommand = cb.GetUpdateCommand();
        daSample.DeleteCommand = cb.GetDeleteCommand();
        daSample.InsertCommand = cb.GetInsertCommand();
        daSample.FillSchema(dtSample, SchemaType.Source);
        dbCon.Open();
    
        // the destination table
        daSample.Fill(dtSample);
        // handle deleted rows
        var drExisting = dtMaster.AsEnumerable()
                    .Select(x => x.Field<int>("Id"));
        var drMasterDeleted = dtSample.AsEnumerable()
                    .Where( q => !drExisting.Contains(q.Field<int>("Id")));
        // delete based on missing ID
        foreach (DataRow dr in drMasterDeleted)
            dr.Delete();
        // merge the XML into the tbl read
        dtSample.Merge(dtMaster,false, MissingSchemaAction.Add);
        int rowsChanged = daSample.Update(dtSample);
    }
