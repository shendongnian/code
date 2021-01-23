    private DataSet GetData(string query, Action<bool> callBack)
    {
        bool successful = false; // This will be returned in the callback.
        DataSet returnValue; // This will be the dataset stuff.
        try
        {
            //do some stuff to populate dataset
            returnValue = ???; // Populate your return value , but don't return yet;
            successful = true; // This will indicate success.
        }
        catch (SqlException ex)
        {
            MessageBox.Show("There was a database error. Please contact administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LogExceptionToFile(ex); //to log whole exception stack trace, etc.
        }
        finally
        {
            //cleanup
    
            if (callBack != null) // Send the callback with the boolean of successful.
            {
                callBack(successful);
            }
            return returnValue; // Now return your DataSet.
        }
    }
    
    bool success = false; // Use this to determine if GetData was successful.
    //calling methods:
    GetData(query, (s) => success = s);
    if (success)
    {
        OtherMethod1(); //this method shows message box of success
    }
    else
    {
        // Do something else, or show your failure message box.
    }
