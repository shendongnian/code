    public DataTable selectDates(DateTime dateFrom, DateTime dateTo)
    {
        initilize();
        _conn.ConnectionString = _cs;
        string query = "Select Sum(tPrice) AS Price from [tblInventory] where Date_Of_Installation BETWEEN @startDate AND @endDate";
        OleDbCommand _cmd = new OleDbCommand(query, _conn);
        cmd.Parameters.AddWithValue("@startDate ", DbType.DateTime).Value = dateFrom;
        cmd.Parameters.AddWithValue("@endDate ", DbType.DateTime).Value = dateTo;
        _da.SelectCommand = _cmd;
        _da.Fill(_dt);
        return _dt;
    }
