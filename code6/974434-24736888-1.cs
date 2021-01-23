    while (sqlreader.Read())
    {
        if (DictFoundExpected.ContainsKey(sqlreader[1].ToString()))
        {
           DictFoundExpected[sqlreader[1].ToString()].IncreaseExpected();
        }
        else
        {
          DictFoundExpected.Add(sqlreader[1].ToString(),new Value(0,0,sqlreader[1].ToString()));
        }
    }
