    public static MySqlDataReader GetALL(String _query, MySqlParameter[] sqlParameter)
        {
            MySqlCommand myCommand = new MySqlCommand();
            try
            {
                 if (con.State == ConnectionState.Open)
                    {
                    con.Close();
                    }
                
                myCommand.Connection = OpenConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.SelectCommand = myCommand;
    
                MySqlDataReader reader = myCommand.ExecuteReader();
                myCommand.Dispose();
                return reader;
            }
            catch (MySqlException ex)
            {
                ErrorLog.ErrorLog.Log_Err("", ex, Global.gUserId.ToString());
                return null;
            }
            finally
            {
            }
        }
