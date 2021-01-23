    using (SqlDataReader rdr = cmd.ExecuteReader())
    {
       while (rdr.Read())
       {
       }
       rdr.NextResultSet();
       while (rdr.Read())
       {
       }
    }
