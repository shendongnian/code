    private bool TryGetData(string query, out DataSet dataSet)
    {
    	try
    	{
            dataSet = ...;
    		//do some stuff to populate dataset
    		return true;
    	}
    	catch (SqlException ex)
    	{
    		MessageBox.Show("There was a database error. Please contact administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    		LogExceptionToFile(ex); //to log whole exception stack trace, etc.
            return false;
        }
    	finally
    	{
    		//cleanup
    	}
    }
    
    //calling methods:
    DataSet ds;
    if (TryGetData(query, out ds))
    {
       OtherMethod1(); 
    }
    else
    {
       //error
    }
