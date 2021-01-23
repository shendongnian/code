    using (var connection = new OracleConnection("DATA SOURCE=HQ_PDB_TCP;PASSWORD=oracle;USER ID=HUSQVIK"))
    {
    	connection.Open();
    	
    	using (var command = connection.CreateCommand())
    	{
    		// Oracle 11
    		command.CommandText = "BEGIN OPEN :C1 FOR SELECT 1 FROM DUAL; OPEN :C2 FOR SELECT 2, 3 FROM DUAL; END;";
    		var p1 = command.CreateParameter();
    		p1.OracleDbType = OracleDbType.RefCursor;
    		p1.Direction = ParameterDirection.Output;		
    		command.Parameters.Add(p1);
    
    		var p2 = command.CreateParameter();
    		p2.OracleDbType = OracleDbType.RefCursor;
    		p2.Direction = ParameterDirection.Output;
    		command.Parameters.Add(p2);
    
    		command.ExecuteNonQuery();
    
    		using (var reader1 = ((OracleRefCursor)p1.Value).GetDataReader())
    		{
    			reader1.Read();
    			
    			Console.WriteLine($"Reader 1 values: {reader1[0]}");
    		}
    
    		using (var reader2 = ((OracleRefCursor)p2.Value).GetDataReader())
    		{
    			reader2.Read();
    
    			Console.WriteLine($"Reader 2 values: {reader2[0]}, {reader2[1]}");
    		}
    		
    		command.Parameters.Clear();
    
    		// Oracle 12
    		command.CommandText = "DECLARE C1 SYS_REFCURSOR; C2 SYS_REFCURSOR; BEGIN OPEN C1 FOR SELECT 1 FROM DUAL; DBMS_SQL.RETURN_RESULT(C1); OPEN C2 FOR SELECT 2, 3 FROM DUAL; DBMS_SQL.RETURN_RESULT(C2); END;";
            using (var implicitReader = command.ExecuteReader())
    		{
    			implicitReader.Read();
    
    			Console.WriteLine($"Implicit cursor 1 values: {implicitReader[0]}");
    			
    			implicitReader.NextResult();
    			implicitReader.Read();
    			
    			Console.WriteLine($"Implicit cursor 2 values: {implicitReader[0]}, {implicitReader[1]}");
    		}
    	}
    }
