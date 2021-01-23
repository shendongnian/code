    using(OleDbConnection myConnection2 = new OleDbConnection(cs))
    {
        myConnection2.Open();
        using(OleDbDataAdapter ad = new OleDbDataAdapter(/*truncated*/, myConnection2))
        {
            [...]
