    StringBuilder SBsmallSquares = new StringBuilder();
    SqlConnection sqlConnection1 = null;
    try
    {
        sqlConnection1 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader ReaderPopup;
        cmd.CommandText = "spUnionServices";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = sqlConnection1;
        cmd.Parameters.AddWithValue("@offset", offset);
        cmd.Parameters.AddWithValue("@fetch", fetch);
        cmd.Parameters.AddWithValue("@freetext", fts);
    
        sqlConnection1.Open();
        ReaderPopup = cmd.ExecuteReader();
        if (ReaderPopup.HasRows)
        {
    	    while (ReaderPopup.Read())
    	    {
    		    //creating the string to return. Here there is no problem.
    	    }
    	    return SBsmallSquares.ToString();
        }
        else return string.Empty;
    }
    catch (Exception ex)
    {
    	// write this out to a text file OR (if you can) examine the exception in the debugger
    	// what you need are
    	// 0. ex.StackTrace <- the full call stack that generated the exception, now you know what method call caused it
    	// 1. ex.GetType().FullName <- the full type of the exception
    	// 2. ex.Message <- the message in the exception
    	// 3. ex.InnerException <- if this is not null then we need the type and message (1 and 2 above) again, this can recurse as many times as needed (the ex.InnerException can have an ex.InnerException.InnerException and that one can also have an InnerException, and so on)
    	// 4. some exceptions have additional details in other properties depending on the type, if you see anything usefull get that too
    
        throw; // rethrow the exception because you do not want to ignore it and pretend everything succeeded (it didn't)
    }
    finally
    {
        if(sqlConnection1 != null) sqlConnection1.Close();
    }
