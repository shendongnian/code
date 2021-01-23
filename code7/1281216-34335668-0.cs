    using(var rdr = check_balance.ExecuteReader())
    {
       while(rdr.Read())
       {
           // I assume your column types mapped with int and string in CLR side
           string balance = rdr.GetInt32(0);
           string withdraw= rdr.GetString(1);
       }
    }
