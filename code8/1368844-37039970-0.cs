    static bool RecordExists(string queryString, OleDbConnection conn)
    {
        bool rtn;
        using (var command = new OleDbCommand(queryString, conn))
        {
            object obj = command.ExecuteScalar();
            int count = obj is DBNull ? 0 : Convert.ToInt32(obj);
            rtn = (count != 0);
        }
        return rtn;
    }
