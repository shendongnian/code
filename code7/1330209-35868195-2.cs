    private DataTable GetDataTable(string strCN, string strSQL)
    {
        try
        {
            using (OleDbConnection _conn = new OleDbConnection(strCN))
            {
                using (OleDbCommand _command = new OleDbCommand())
                {
                    _command.CommandType = CommandType.Text;
                    _command.Connection = _conn;
                    _command.CommandText = strSQL;
                    _conn.Open();
    
                    using (OleDbDataReader _dr = _command.ExecuteReader())
                    {
                        DataTable _dt = new DataTable();
                        _dt.Load(_dr);
                        return _dt;
                    }
                }
            }
        }
        catch
        {
            throw;
        }
    }
