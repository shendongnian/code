    const string _createTableString = "Create table #temp (/* SNIP */)";
    const string _insertTableString = @"
    declare @sql nvarchar(2000)
    set @sql = N'INSERT INTO ' + QUOTENAME(@tableName) + N' SELECT * from #temp'
    exec sp_executesql @sql";
    
    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
    {
        connection.Open();
        using (var command = new SqlCommand(_createTableString, connection))
        {
            command.ExecuteNonQuery();
        }
        using (var copy = new SqlBulkCopy(connection))
        {
            copy.DestinationTableName = "#temp";
            copy.WriteToServer(table);
        }
        using (var command = new SqlCommand(_insertTableString, connection))
        {
            command.Parameters.AddWithValue("@tableName", obj.TableName)
            command.ExecuteNonQuery();
        }
    }
