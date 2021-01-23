    string cs = @"Your connection string bla bla";
    
    using(SqlConnection con = new SqlConnection(cs))
    {
      string sqlQuery = "UPDATE B SET B.Marks = A.Marks
                         FROM TableB B 
                         INNER JOIN TableA A ON  A.Name = B.Name 
                                                AND  A.ID = B.ID"
        using(SqlCommand cmd = new SqlCommand(sqlQuery, con))
        { 
            con.Open();
            cmd.ExecuteNonQuery();
    
        }
    }
