    while (sqlreader.Read())
    {
      string key = sqlreader[1].ToString();
      if (DictFoundExpected.ContainsKey(key))
      {
        Value v = DictFoundExpected[key];
        DictFoundExpected[key]= new Value(v.Found, v.Expected + 1, v.Code);
      }
      else {
        DictFoundExpected.Add(key,new Value(0,0,sqlreader[1].ToString()));
      }
    }
