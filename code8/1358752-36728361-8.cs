    try
    {
         conn.Open();
         using(SqlDataAdapter da = new SqlDataAdapter(cm))
         {
              da.Fill(DataTable dt);
         }
    }
