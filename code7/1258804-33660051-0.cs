    string start = monthCalendar1.SelectionRange.Start.ToShortDateString();
    string end = monthCalendar1.SelectionRange.End.ToShortDateString();
    DateTime startDay = Convert.ToDateTime(start);
    DateTime endDay = Convert.ToDateTime(end);
    _startDate = startDay;
    _endDate = endDay;
    var VacationDate = _startDate.ToShortDateString();
    do
    {
        VacationDate = _startDate.ToShortDateString();
        command.Parameters.AddWithValue("vDate", VacationDate);
        command.CommandText = "insert into " + user + " (Date) values (@vDate)";
        command.Connection = con;
        command.ExecuteNonQuery();      
        string query = "select * from " + user;
        command.CommandText = query;
        OleDbDataAdapter Daten = new OleDbDataAdapter(command);
        DataTable Datenquelle = new DataTable();
        Daten.Fill(Datenquelle);        
        dataGridView1.DataSource = Datenquelle;
        _startDate = _startDate.AddDays(1);
    }
    while (_startDate <= _endDate);
    {
        Debug.WriteLine(startDay);
        startDay = startDay.AddDays(1);
    }
