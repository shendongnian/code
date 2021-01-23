    string[] validColumns = SQL_Columns.Split(',');
        var trimmed = validColumns.Select(c => c.Trim());
        foreach(DataColumn column in p_UpdatesTable.Columns)
        {
          if(!column.ColumnName.EndsWith("_null") && !trimmed.Contains(column.ColumnName))
          {
            throw new Exception("Column '" + column.ColumnName + "' is not valid for table");
          }
        }
        string tableTypeName = "dbo.UpdateSpecific" + Guid.NewGuid().ToString().Replace("-", "").Replace("{", "").Replace("}", "");
        StringBuilder tableTypeBuilder = new StringBuilder();
        tableTypeBuilder.Append("CREATE TYPE ");
        tableTypeBuilder.Append(tableTypeName);
        tableTypeBuilder.Append(" AS TABLE (");
        List<string> tableTypeColumns = new List<string>(p_UpdatesTable.Columns.Count);
        StringBuilder commandBuilder = new StringBuilder();
        commandBuilder.Append("UPDATE Table SET ");
        List<string> columnsToUpdate = new List<string>(p_UpdatesTable.Columns.Count);
        foreach (DataColumn column in p_UpdatesTable.Columns)
        {
          //build command to create table type
          StringBuilder columnTypeBuilder = new StringBuilder();
          columnTypeBuilder.Append("[");
          columnTypeBuilder.Append(column.ColumnName);
          columnTypeBuilder.Append("] ");
          if(column.DataType == typeof(int))
          {
            columnTypeBuilder.Append("INT");
          }
          else if(column.DataType == typeof(long))
          {
            columnTypeBuilder.Append("BIGINT");
          }
          else if(column.DataType == typeof(bool))
          {
            columnTypeBuilder.Append("BIT");
          }
          else if(column.DataType == typeof(string))
          {
            columnTypeBuilder.Append("VARCHAR(");
            columnTypeBuilder.Append(column.MaxLength);
            columnTypeBuilder.Append(")");
          }
          else if(column.DataType == typeof(byte[]))
          {
            columnTypeBuilder.Append("IMAGE");
          }
          tableTypeColumns.Add(columnTypeBuilder.ToString());
          //build actual update statement
          if (!column.ColumnName.Equals("UID", StringComparison.InvariantCultureIgnoreCase) && !column.ColumnName.EndsWith("_null"))
          {
            StringBuilder columnBuilder = new StringBuilder();
            columnBuilder.Append(column.ColumnName);
            columnBuilder.Append(" = (CASE WHEN U.");
            columnBuilder.Append(column.ColumnName);
            columnBuilder.Append(" IS NULL THEN (CASE WHEN ISNULL(U.");
            columnBuilder.Append(column.ColumnName);
            columnBuilder.Append("_null, 0) = 1 THEN U.");
            columnBuilder.Append(column.ColumnName);
            columnBuilder.Append(" ELSE C.");
            columnBuilder.Append(column.ColumnName);
            columnBuilder.Append(" END) ELSE U.");
            columnBuilder.Append(column.ColumnName);
            columnBuilder.Append(" END)");
            columnsToUpdate.Add(columnBuilder.ToString());
          }
        }
        tableTypeBuilder.Append(string.Join(",", tableTypeColumns.ToArray()));
        tableTypeBuilder.Append(")");
        commandBuilder.Append(string.Join(",", columnsToUpdate.ToArray()));
        commandBuilder.Append(" FROM Table AS C JOIN @UpdateTable AS U ON C.UID = U.UID");
        //Establish SQL Connection
        using (SqlConnection sqlConnection = new SqlConnection(context.strContext[(int)eCCE_Context._CONNECTION_STRING]))
        {
          sqlConnection.Open();
          try
          {
            using (SqlCommand createTableTypeCommand = new SqlCommand(tableTypeBuilder.ToString(), sqlConnection))
            {
              createTableTypeCommand.ExecuteNonQuery();
            }
            using (SqlCommand sqlCommand = new SqlCommand(commandBuilder.ToString(), sqlConnection))
            {
              SqlParameter updateTableParameter = sqlCommand.Parameters.Add("@UpdateTable", SqlDbType.Structured);
              updateTableParameter.Value = p_UpdatesTable;
              updateTableParameter.TypeName = tableTypeName;
              int rowsAffected = sqlCommand.ExecuteNonQuery();
              if (rowsAffected != p_UpdatesTable.Rows.Count)
              {
                throw new Exception("Update command affected " + rowsAffected + " rows out of the " + p_UpdatesTable.Rows.Count + " expected.");
              }
            }
          }
          finally
          {
            string dropStatement = "IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'"+ tableTypeName.Substring(tableTypeName.IndexOf(".")+1) +"' AND ss.name = N'dbo') DROP TYPE " + tableTypeName;
            using (SqlCommand dropTableTypeCommand = new SqlCommand(dropStatement, sqlConnection))
            {
              dropTableTypeCommand.ExecuteNonQuery();
            }
          }
          sqlConnection.Dispose();
        }
