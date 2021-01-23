    using (Context dbContext = createDbInstance())
    {
        //Not happy about setting MultipleActiveResultSets
        string conn = dbContext.Database.Connection.ConnectionString + ";MultipleActiveResultSets=True";
        
        using (var connection = new SqlConnection(conn))
        using (var newInsertCmd = new SqlCommand(connection))
        {
            newInsertCmd.Connection.Open();
			//Set up input variables here, including a TPV
    
			List<string> results = new List<string>();
    
	        //The two insert statements work just fine. The other junk here (including the OUTPUT clause) is brand new
			const string qryInsertTrans =
				@"BEGIN TRY
                    BEGIN TRANSACTION;
                    INSERT INTO Parent ([Name], [CreateDate])
                    SELECT n.Name, GETUTCDATE() [CreateDate]
                    FROM @NewRecords n
                        LEFT JOIN Parent p ON n.Name = p.Name
                    WHERE p.ParentID IS NULL;
    
                    DECLARE @OutputVar table(
                    ParentID bigint NOT NULL
                    );
    
                    INSERT INTO Child ([ParentID], [SomeText], [CreateDate])
                    OUTPUT INSERTED.ParentID INTO @OutputVar
                    SELECT p.ParentID, n.Text, GETUTCDATE() [CreateDate]
                    FROM @NewRecords n
                        INNER JOIN Parent p ON n.Name = p.Name
                    LEFT JOIN Child c ON p.ParentID = c.ParentID AND c.SomeCol = @SomeVal
                    WHERE c.ChildID IS NULL;
    
                    SELECT p.Name
                    FROM Parent p INNER JOIN @OutputVar o ON p.ParentID = o.ParentID
                    COMMIT TRAN;                          
				END TRY
                BEGIN CATCH
                ROLLBACK TRAN;
                THROW;
                END CATCH;";
    
			newInsertCmd.CommandText = qryInsertTrans;
			using(var reader = await newInsertCmd.ExecuteReaderAsync())
			{
				while (reader.Read())
				{
					results.Add(reader["Name"].ToString());
				}
			}
		}
	}
