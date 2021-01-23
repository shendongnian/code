    void SqlExecuteCommand(string CommandSQL)
    {
        try
        {
            using (SqlConnection _connSqlCe = new SqlConnection("Conn String to SQL DB"))
            {
                _connSql.Open();
                using (SqlCommand _commandSqlCe = new SqlCommand(CommandSQL, _connSql))
                {
                    _commandSql.CommandType = CommandType.Text;
                    var _i = _commandSql.ExecuteScalar();
                }
            }
        }
        catch { throw; }
    }
