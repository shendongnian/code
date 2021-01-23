    private DataTable GetDtaTest(string strCN, string strSQL)
    {
        try
        {
            // in conn string
            using (OleDbConnection _connSqlCe = new OleDbConnection(strCN))
            {
                using (OleDbCommand _commandSqlCe = new OleDbCommand())
                {
                    _commandSqlCe.CommandType = CommandType.Text;
                    _commandSqlCe.Connection = _connSqlCe;
                    _commandSqlCe.CommandText = strSQL;
                    _connSqlCe.Open();
    
                    using (OleDbDataReader _drSqlCe = _commandSqlCe.ExecuteReader())
                    {
                        DataTable _dt = new DataTable();
                        _dt.Load(_drSqlCe);
                        _connSqlCe.Close();
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
