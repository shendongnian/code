    string sql2 = @"select max(day) as day from users u 
    join days d on d.User_ID = u.id 
    where u.ActiveUser = 1 and u.id = @id";
    
    string sql = @"SELECT MAX(Day) FROM Days 
    WHERE Project_ID IN 
    (SELECT ID FROM Projects WHERE Parent_ID = -1 AND ID = @id)
    HAVING MAX(Day) < DATEADD(dd, -730, getdate())";
    
    DateTime dt;
    using (conn)
    {
      using (SqlCommand cmd = new SqlCommand(sql2, conn))
      {
        command.Parameters.AddWithValue("@id", (Int64)Users["ID"]);
        conn.Open();
        dt = (DateTime)command.ExecuteScalar();
      }
    }
    
    using (conn)
    {
      using (SqlCommand cmd = new SqlCommand(sql, conn))
      {
        command.Parameters.AddWithValue("@id", (Int64)row["ID"]);
        conn.Open();
        dt = (DateTime)command.ExecuteScalar();
      }
    }
