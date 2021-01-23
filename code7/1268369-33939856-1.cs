    sql = con.CreateCommand();
    sql.CommandText = "select [ZeitH] from [Tisch 1] where [Datum]='" + datum + "';";
    OleDbDataReader reader = sql.ExecuteReader();
    
    var Temp = T1;
    
    while (reader.Read())
    {
        for (int i = 0; i <= 10; i++)
        {
            if (reader.GetInt32(0).ToString() == (i + 10).ToString())
            {
                if( your condition)
                {
                    Temp = T2;
                }
    
                Temp[i] = false;
                Temp[i + 1] = false;
                Temp[i + 2] = false;
                Temp[i + 3] = false;
            }
        }
    }
