    DataTable table = new DataTable();
    table.Columns.Add("MyColumn", typeof(string));
    //Your rest code (connection object and all)
    sqlCmd2.CommandText = "SELECT COLUMN_NAME  AS MyColumn
                           FROM INFORMATION_SCHEMA.COLUMNS
                           WHERE TABLE_NAME = @TableName";
    sqlCmd2.Parameters.Add("@TableName",SqlDbType.NVarChar).Value = "registrants";
    sqlConn2.Open();
    using (SqlDataReader reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
           DataRow tableRow = table.NewRow();
           tableRow["MyColumn"] = reader["MyColumn"].ToString();
           table.Rows.Add(tableRow);
         }
         Repeater1.DataSource = table;
         Repeater1.DataBind();
    }
    
