    public DataTable selectDates(DateTime dateFrom, DateTime dateTo)
    {
        initilize();
        _conn.ConnectionString = _cs;
        _cmd.Connection = _conn;
        string query = string.Format("Select Sum(tPrice) AS Price from [tblInventory] where Date_Of_Installation BETWEEN #{0}# AND #{1}#", dateFrom.ToString("yyyy/MM/dd"), dateTo.ToString("yyyy/MM/dd"));
        _cmd.CommandText = query;
        _da.SelectCommand = _cmd;
        _da.Fill(_dt);
        return _dt;
    }
