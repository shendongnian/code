    string connectionstring = "server=.;database=Student;Integrated Security=True";
    using(SqlConnection con = new SqlConnection(connectionstring ))
    using(SqlCommand cmd = con.CreateCommand())
    {
         ...
         con.Open();
         cmd.ExecuteNonQuery();
    }
