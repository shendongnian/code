    int i = dtMain.Rows.Count ;
    while ( i > 0)
    {
       var query = dt.AsEnumerable().Except(dtSuccess.AsEnumerable(), DataRowComparer.Default)
                     .AsEnumerable().Except(dtFail.AsEnumerable(), DataRowComparer.Default);
       if (dtMain.AsEnumerable().Any())
            dtMain = query.CopyToDataTable();
       Thread.SLeep(10000);
       i = dtMain.Rows.Count ;
    }
