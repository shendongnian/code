    var idTemp = Run_ExecuteScaler(string.Format(
                            "SELECT id FROM myTable where Category='{0}'", newCatTitle));
    
    if (idTemp == null)
    {
      //Insert into table
    }
    else
    {
      //Message it already exists
    }
 *******************************************
    public static object Run_ExecuteScaler(string query)
     {
            object objResult = null;
            _cnt = new SqlCeConnection();
            _cnt.ConnectionString = ConnectionString;
            _cmd = new SqlCeCommand();
            _cmd.Connection = _cnt;
            _cmd.CommandType = System.Data.CommandType.Text;
            _cmd.CommandText = query;
            if (_cnt.State != System.Data.ConnectionState.Open)
                _cnt.Open();
            objResult = _cmd.ExecuteScalar();
            _cmd.Dispose();
            if (_cnt.State != System.Data.ConnectionState.Closed)
                _cnt.Close();
            _cnt.Dispose();
            return objResult;
     }
