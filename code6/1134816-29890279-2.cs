    bool TryGetInt(OleDbCommand Command, int ValueIfException, out int Value) 
    {
        try
        {
            if(Connection.State == ConnectionState.Closed || Connection.State == ConnectionState.Broken) 
            {
              Connection.Open();
            }
             Value = (int)Command1.ExecuteScalar();
             return true;
        }
        catch (Exception)
        {
             // Consider writing the exception into a log file
             Value = ValueIfException;
             return false;
        }
    }
