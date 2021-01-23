    //First determine which table should be considered 'Main'. This will be the one with the LEAST number of rows.
    var dsRowCount = ds.AsEnumerable().Count();
    var dtRowCount = dt.AsEnumerable().Count();
    if (dsRowCOunt > dtRowCount)
    {
        //Set main table to be dt as this has the least number of rows.
        datagridView.Datasource = NoMatches(dt, ds);
    }
    else
    {
        //Set main table to ds as this has the least number of rows OR tables have the same number of rows.
        datagridView.Datasource = NoMatches(ds, dt);
    }
