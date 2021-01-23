    #region private: Get DataTable using SqlCeDataReader
    /// <summary>
    /// Get DataTable using SqlCeDataReader
    /// </summary>
    /// <param name="strConn">string</param>
    /// <param name="strSQL">string</param>
    /// <returns>DataTable</returns>
    private static DataTable GetDataTableFromFileCeReader(string strConn, string strSQL)
    {
        try
        {
            using (SqlCeConnection _connSqlCe = new SqlCeConnection(strConn))
            {
                using (SqlCeCommand _commandSqlCe = new SqlCeCommand())
                {
                    _commandSqlCe.CommandType = CommandType.Text;
                    _commandSqlCe.Connection = _connSqlCe;
                    _commandSqlCe.CommandText = strSQL;
                    _connSqlCe.Open();
    
                    using (SqlCeDataReader _drSqlCe = _commandSqlCe.ExecuteReader()) {
                        DataTable _dt = new DataTable();
                        _dt.Load(_drSqlCe);
                        _connSqlCe.Close();
                        return _dt;
                    }
                }
            }
        }
        catch { throw; }
    }
    #endregion
