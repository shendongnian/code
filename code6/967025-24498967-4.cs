    // Placeholder for the real collection
    IEnumerable<Tuple<Guid, Guid>> cGUIDs;
    // create a data table that will be used to hold your GUIDs
    var oTable = new DataTable("GUIDs");
    oTable.Columns.Add("GUID_A", typeof(Guid));
    oTable.Columns.Add("GUID_B", typeof(Guid));
    // Add each of the guids from ienumerable to the datatable
    foreach (var oTuple in cGUIDs)
    {
        oTable.Rows.Add(oTuple.Item1, oTuple.Item2);
    }
    using (var oConnection = new SqlConnection("Server=localhost;Database=YourDatabase;Trusted_Connection=True;"))
    {
        oConnection.Open();
        using (var oCommand = new SqlCommand("s_Get_GUIDs", oConnection))
        {
            oCommand.CommandType = CommandType.StoredProcedure;
            var oParameter = oCommand.Parameters.AddWithValue("@TVPGuids", oTable);
            // This is necessary so ado.net knows we are passing a table-valued parameter
            oParameter.SqlDbType = SqlDbType.Structured;
            oCommand.ExecuteReader();
            
            // ToDo: Add remaining code here
        }
        oConnection.Close();
    }
