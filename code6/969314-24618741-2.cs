    using (Context dbContext = createDbInstance())
    {
        List<string> results = new List<string>();
    
        //Not happy about setting MultipleActiveResultSets
        string conn = dbContext.Database.Connection.ConnectionString + ";MultipleActiveResultSets=True";
        
        using (var connection = new SqlConnection(conn))
        {
            newInsertCmd.Connection.Open();
            using(SqlTransaction sqlTran = newInsertCmd.Connection.BeginTransaction())
            {
                try
                {
                    using (var parentInsert = new SqlCommand(connection))
                    {
                        parentInsert .Transaction = sqlTran;
    
                        //Set up input variables here, including a TPV
    
                        newInsertCmd.CommandText = 
                                @"INSERT INTO Parent ([Name], [CreateDate])
                                SELECT n.Name, GETUTCDATE() [CreateDate]
                                FROM @NewRecords n
                                LEFT JOIN Parent p ON n.Name = p.Name
                                WHERE p.ParentID IS NULL;";
                        await newInsertCmd.ExecuteNonQueryAsync();
                    }
                    using (var childInsert = new SqlCommand(connection))
                    {
                        childInsert.Transaction = sqlTran;
    
                        //Set up input variables here, including a TPV
    
                        newInsertCmd.CommandText = 
                              @"DECLARE @OutputVar table(
                                  ParentID bigint NOT NULL
                              );
    
                              INSERT INTO Child ([ParentID], [SomeText], [CreateDate])
                              OUTPUT INSERTED.ParentID INTO @OutputVar
                              SELECT p.ParentID, n.Text, GETUTCDATE() [CreateDate]
                              FROM NewRecords n
                              INNER JOIN Parent p ON n.Name = p.Name
                              LEFT JOIN Child c ON p.ParentID = c.ParentID AND c.SomeCol = @SomeVal
                              WHERE c.ChildID IS NULL;
    
                              SELECT p.Name
                              FROM Parent p INNER JOIN @OutputVar o ON p.ParentID = o.ParentID";
    
                       using(var reader = await childInsert.ExecuteReaderAsync())
                       {
                           while (reader.Read())
                           {
                               results.Add(reader["Name"].ToString());
                           }
                       }
                    }
                    sqlTran.Commit();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
    
                    try
                    {
                        sqlTran.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Debug.WriteLine(exRollback.Message);
                        throw;
                    }
    
                    throw;
                }
            }
        }
    }
