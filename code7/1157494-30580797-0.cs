    private static DataTable SqlReadDB(string ConnString, string SQL)
    {
        DataTable _dt;
        try
        {
            using (SqlConnection _connSql = new SqlConnection(ConnString))
            {
                using (SqlCommand _commandl = new SqlCommand(SQL, _connSql))
                {
                    _commandSql.CommandType = CommandType.Text;
                    _connSql.Open();
                    using (SqlCeDataReader _dataReaderSql = _commandSql.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        _dt = new DataTable();
                        _dt.Load(_dataReaderSqlCe);
                        _dataReaderSql.Close();
                    }
                }
                _connSqlCe.Close();
                return _dt;
            }
        }
        catch { return null; }
    }
