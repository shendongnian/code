    catch (Exception exp)
        {
            if (exp.GetBaseException() is System.Data.SqlClient.SqlException)
            {
                var sqlException = exp.GetBaseException() as System.Data.SqlClient.SqlException;
        
                if (sqlException != null && sqlException.Number == 547)
                {
                    //do something
                }
            }
            //do something
        }
