    private static void Demo1()
    {
    	SqlConnection db = new SqlConnection("connstringhere");
    	SqlTransaction transaction;
    
    	db.Open();
    	transaction = db.BeginTransaction();
    	try
    	{
    		var updateResultNums = new SqlCommand("UPDATE", db, transaction).ExecuteNonQuery();
    		var deleteResultNums = new SqlCommand("DELETE", db, transaction).ExecuteNonQuery();
    		var reader = new SqlCommand("SELECT", db, transaction).ExecuteReader();
    		while (reader.Read())
    		{
    			// read
    			// alternatively see http://stackoverflow.com/a/13870892/1260204 if you really want a data table from the SqlCommand
    		}
    		transaction.Commit();
    	}
    	catch (SqlException sqlError)
    	{
    		transaction.Rollback();
    		// do something to handle error
    	}
    	finally
    	{
    		db.Close(); //close connection
    		db.Dispose(); //dispose connection
    		transaction.Dispose();
    	}
    }
