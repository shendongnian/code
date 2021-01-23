    /// <summary>
    /// Read DB Read Scalar on SQL command input
    /// </summary>
    /// <param name="SQL">string</param>
    /// <returns>string</returns>
    private static string ReadScalar(string ConnString, string SQL)
    {
        string _ret;
        try
        {
            using (OleDbConnection _conn = new OleDbConnection(ConnString))
            {
                using (OleDbCommand _command = new OleDbCommand(SQL, _conn))
                {
                    _command.CommandType = CommandType.Text;
                    _conn.Open();
                    _ret = _command.ExecuteScalar().ToString();
                }
                return _ret;
            }
        }
        catch { return null; }
    }
