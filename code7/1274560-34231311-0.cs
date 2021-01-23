    var jsonString = String.Empty;
    context.Request.InputStream.Position = 0;
    using (var inputStream = new StreamReader(context.Request.InputStream))
    {
        jsonString = inputStream.ReadToEnd();
        var results = JsonConvert.DeserializeObject<dynamic>(jsonString);
        var columns = results.columns;
        var rows = results.rows;
    
        var dt = new DataTable();
        for (int i = 0; i < columns.Count; i++)
        {        
            dt.Columns.Add(columns[i].ToString());
        }
        
        foreach (var row in rows)
        {
            var datarow = dt.NewRow();
            for (int i = 0; i < row.Count; i++)
            {
                datarow[i] = row[i];
            }
            dt.Rows.Add(datarow);
        }
    
        using (var connection = new SqlConnection(ConnectionString))
        {
            SqlTransaction transaction = null;
            connection.Open();
            try
            {
                transaction = connection.BeginTransaction();
                using (var sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.TableLock, transaction))
                {
                    sqlBulkCopy.DestinationTableName = "TABLENAME";
                    sqlBulkCopy.BatchSize = 100000;
                    sqlBulkCopy.BulkCopyTimeout = 0;
                    foreach (DataColumn col in dt.Columns)
                    {
                        sqlBulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                    }
                    sqlBulkCopy.WriteToServer(dt);
                }
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }
    }
