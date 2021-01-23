    public int insertLocation(string name)
            {
                try
                {
                    dataconnection.insertStatements(cmd);
                }
                catch (FaultException ex)
                {
                    // you should handle the exception here. Do not retrow here too. Otherwise you may need to handle somewhere else again.
                }
            }
            public int insertStatements(SqlCommand cmd)
            {
                try
                {
                    //insert data to the db
    
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // if unique key constraint error
                    {
                        throw new FaultException("error reason", new FaultCode("Error Code: ");
                    }
                    else
                    {
                        throw new FaultException("DB error: ", new FaultCode("Error Code: ");
                    }
                }
            }
