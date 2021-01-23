    using (var conn = new SqlConnection(@"Data Source=.;Initial Catalog=Test;Integrated Security=True"))
    {
        conn.Open();
    
        using (var setupTable = new SqlCommand(@"
            IF NOT EXISTS (
    	        SELECT *
    	        FROM
    		        sys.schemas s
    			        INNER JOIN sys.tables t ON
    				        t.[schema_id] = s.[schema_id]
    	        WHERE
    		        s.name = 'dbo' AND
    		        T.name = 'TimeoutTest')
            BEGIN
    	        CREATE TABLE dbo.TimeoutTest
    	        (
    		        ID int IDENTITY(1,1) PRIMARY KEY,
    		        CreateDate datetime DEFAULT(getdate())
    	        );
            END
    
            -- remove any rows from previous runs
            TRUNCATE TABLE dbo.TimeoutTest;", conn))
        {
            setupTable.ExecuteNonQuery();
        }
    
        using (var checkProcExists = new SqlCommand(@"
            SELECT COUNT(*)
            FROM
    	        sys.schemas s
    		        INNER JOIN sys.procedures p ON
    			        p.[schema_id] = s.[schema_id]
            WHERE
    	        s.name = 'dbo' AND
    	        p.name = 'AddTimeoutTestRows';", conn))
        {
            bool procExists = ((int)checkProcExists.ExecuteScalar()) == 1;
    
            if (!procExists)
            {
                using (var setupProc = new SqlCommand(@"
                    CREATE PROC dbo.AddTimeoutTestRows
                    AS
                    BEGIN
    
    	                DECLARE @stop_time datetime;
    
    	                SET @stop_time = DATEADD(minute, 1, getdate());
    
    	                WHILE getdate() < @stop_time
    	                BEGIN
    		                INSERT INTO dbo.TimeoutTest DEFAULT VALUES;
    
    		                -- wait 10 seconds between inserts
    		                WAITFOR DELAY '0:00:10';
    	                END
    
                    END", conn))
                {
                    setupProc.ExecuteNonQuery();
                }
            }
        }
    
        bool commandTimedOut = false;
    
        try
        {
            using (var longExecution = new SqlCommand("EXEC dbo.AddTimeoutTestRows;", conn))
            {
                // The time in seconds to wait for the command to execute.
                // Explicitly setting the timeout to 30 seconds for clarity.
                longExecution.CommandTimeout = 30;
    
                longExecution.ExecuteNonQuery();
            }
        }
        catch (SqlException ex)
        {
            if (ex.Message.Contains("Timeout"))
            {
                commandTimedOut = true;
            }
            else
            {
                throw;
            }
        }
    
        Console.WriteLine(commandTimedOut.ToString());
    
        // Wait for an extra 30 seconds to let any execution on the server add more rows.
        Thread.Sleep(30);
    
        using (var checkTableCount = new SqlCommand(@"
            SELECT COUNT(*)
            FROM
    	        dbo.TimeoutTest t;", conn))
        {
            // Only expecting 3, but should be 6 if server continued on without us.
            int rowCount = (int)checkTableCount.ExecuteScalar();
    
            Console.WriteLine(rowCount.ToString("#,##0"));
        }
    }
    
    Console.ReadLine();
