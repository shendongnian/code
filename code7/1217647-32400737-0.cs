    DataTable dt = new DataTable();
    dt.Columns.Add("ID", Type.GetType("System.Guid"));
    
    foreach (Guid guid in filter.FetchIDs)
    {
        DataRow row = dt.NewRow();
        row["ID"] = guid;
        dt.Rows.Add(row);
    }
    sqlCmd.CommandText = "SELECT * FROM Site INNER JOIN @idList as FetchIDs on FetchIDs.ID=Site.ID;";
    SqlParameter parameter = sqlCmd.Parameters.Add("@idList", SqlDbType.Structured);
    parameter.TypeName = "[dbo].[SiteType]";
    parameter.Value = dt;
