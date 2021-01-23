    using(OleDbDataReader reader = command.ExecuteReader())
    {
        if (myreader.Read())
        {
           string sName = reader.GetString(1);
           ...
        }
     }
