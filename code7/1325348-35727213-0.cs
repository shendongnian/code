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
    		db.Close();
    		transaction.Dispose();
    	}
    }
