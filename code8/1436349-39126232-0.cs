    public SqlCommand InitSqlCommand(string query,CommandType commandType)
    {
        var Sqlcommand = new SqlCommand(query, con);
        Sqlcommand.CommandType = commandType;
        return Sqlcommand;
    }
