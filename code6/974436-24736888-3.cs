    while (sqlreader.Read())
    {
        String currentCode = sqlreader[1].ToString();
        if (DictFoundExpected.ContainsKey(currentCode))
        {
           DictFoundExpected[currentCode].IncreaseExpected();
        }
        else
        {
          DictFoundExpected.Add(currentCode,new Value(0,0,currentCode));
        }
    }
