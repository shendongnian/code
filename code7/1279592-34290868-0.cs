    string sql = @"select u.Id, max(day) as day 
      from users u 
      join days d on d.User_ID = u.id 
      where u.ActiveUser = 1
      group by u.id";
    
    DataTable tbl = new DataTable();
    using (conn)
    {
      using (SqlCommand cmd = new SqlCommand(sql, conn))
      {
        conn.Open();
        tbl.Load( cmd.ExecuteReader() );
        conn.Close();
      }
    }
    
    var dates = tbl.AsEnumerable()
                   .ToDictionary(t => t.Field<Int64>("ID"), 
                                 t => t.Field<DateTime?>("Day"));
