    using(var rdr = check_balance.ExecuteReader())
    {
       while(rdr.Read())
       {
           string balance = rdr.GetInt32(0);
           string withdraw= rdr.GetInt32(1);
       }
    }
