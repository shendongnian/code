    public bool TruncateTable(string tableName)
    {
        string sqlTrunc = $"Delete from {tableName}";
    
        if (isSafeSqlConnection(sqlConnection))
        {
            DisableAllForeignKeys();
    
            using (sqlConnection)
            {
                DeleteAllDependencies(tableName, sqlConnection);
    
                SqlCommand cmd = new SqlCommand(sqlTrunc, sqlConnection);
                sqlConnection.Open();
                success = cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
    
            EnableAllForeignKeys();
        }
        return success;
    }
    public void DisableAllForeignKeys(SqlConnection sqlConnection)
    {
        using(var command = new SqlCommand($"EXEC sp_msforeachtable \"ALTER TABLE ? NOCHECK CONSTRAINT all\"", sqlConnection))
            command.ExecuteNonQuery();
    }
    
    public void EnableAllForeignKeys(SqlConnection sqlConnection)
    {
        using(var command = new SqlCommand($"EXEC sp_msforeachtable \"ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all\"", sqlConnection))
            command.ExecuteNonQuery();
    }
    
    private static void DeleteAllDependencies(string tableName, SqlConnection sqlConnection)
    {
        var sql =
            $@"SELECT t.name  AS 'Table that contains FK', 
    fk.name AS 'FK Name',
    t1.Name AS 'Table that is being referenced'
    FROM   sys.foreign_key_columns fkc 
    INNER JOIN sys.tables t ON t.object_id = fkc.parent_object_id 
    INNER JOIN sys.tables t1 ON t1.object_id = fkc.referenced_object_id
    INNER JOIN sys.columns c1 ON c1.object_id = fkc.parent_object_id AND c1.column_id = fkc.parent_column_id 
    INNER JOIN sys.foreign_keys fk ON fk.object_id = fkc.constraint_object_id 
    INNER JOIN sys.schemas sc ON t.schema_id = sc.schema_id
    WHERE  (sc.name + '.' +t1.name) = 'dbo.{
                tableName}';";
    
        var command = sqlConnection.CreateCommand();
        command.CommandText = sql;
    
        List<Tuple<string, string, string>> tuples;
        using (var dataReader = command.ExecuteReader())
        {
            var enumerator = dataReader.GetEnumerator();
            tuples = Enumerable.Range(1, int.MaxValue)
                               .TakeWhile(i => enumerator.MoveNext())
                               .Select(i => (IDataRecord)enumerator.Current)
                               .Select(dr => Tuple.Create(dr.GetString(0), dr.GetString(1), dr.GetString(2)))
                               .ToList();
        }
    
    
        foreach (var tuple in tuples)
        {
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandText = $"DELETE FROM {tuple.Item1}";
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
