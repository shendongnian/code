    private DataSet GetData(string query)
    {
        try
        {
            //do some stuff to populate dataset
            return dataset;
        }
        catch (SqlException ex)
        {
            MessageBox.Show("There was a database error. Please contact administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LogExceptionToFile(ex); //to log whole exception stack trace, etc.
            throw;
        }
        finally
        {
            //cleanup
        }
    }
