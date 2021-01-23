    void readSettings()
    {
    DataTable dt = new DataTable();
    dt.ReadXml(@"filename_goes_here");
    int entriesCount = dt.Rows.Count;
    int i=0;
    while(i<entriesCount)
    {
    switch(dt.Rows[i][0])
    {
    case "Speed":
    try
    {
    _timer.Interval=Int32.Parse(dr.Rows[i][1]);
    }
    catch
    { // we've got a problem !
    }
    break;
    default:break;
    }
    i++;
    }
    }
