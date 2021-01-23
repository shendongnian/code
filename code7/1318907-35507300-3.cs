    var query = dtTest.AsEnumerable();
    for (int i = 0; i < 4; ++i)
      if (dropdown #i-1 index > 0) {
        query = query.Where(r => r.Field<string>(strSelectedCol) == ViewState[strSelectedType].ToString());
        var result = query.CopyToDataTable();
        //Do something, your DataTable is here
      }
