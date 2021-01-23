    var _data = new My.EF.MyEntities();
    try
    {
       
        for (int i = 1; i < 17348; i++)
        {
            try
            {
              //Do lots of stuff
            }
            catch (SqlException ex)
            {
                WriteLogFile("Error at id" + i.ToString(), ex);
                i--;
                if (_data.Database.Connection.State != System.Data.ConnectionState.Open)
                {
                    ((IDisposable)_data).Dispose();
                    _data = new My.EF.MyEntities()
                }
            }
        }
    }
    finally
    {
        if (_data != null)
        {
            ((IDisposable)_data).Dispose();
        }
    }
