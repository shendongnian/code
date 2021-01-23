    private static SqlConnection _Connection = new SqlConnection();
    private static SqlCommand _Command = new SqlCommand();
    private static SqlConnection _Conn = new SqlConnection();
    
    private static SqlConnection GetConnection()
        {
            try
            {
                if (_Connection.State == ConnectionState.Closed)
                {
                _Connection.ConnectionString = "ConnectionString";
                _Connection.Open();
                }
                return _Connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    public static void UpdateData(params object[] ParamValue)
        {
            try
            {
                _Conn = GetConnection();
                _Command.Connection = _Conn;
                _Command.CommandTimeout = 0;
                _Command.CommandType = CommandType.StoredProcedure;
                _Command.CommandText = "updateprocedure";
                _Command.Parameters.Clear();
                _Command.Parameters.Add("@Paramname1", SqlDbType.Int).Value = ParamValue[0];
                _Command.Parameters.Add("@Paramname2", SqlDbType.Int).Value = ParamValue[1];
                _Command.Parameters.Add("@Paramname3", SqlDbType.Int).Value = ParamValue[2];
               
                _Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
