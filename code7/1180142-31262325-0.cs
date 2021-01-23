    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
    {
       SqlCommand cmd = new SqlCommand("select * from testtable where id=@id", con);
       adapter = new SqlDataAdapter(cmd);
       cmd.Parameters.AddWithValue("@id", 1);
       adapter.Fill(dt);
                
    }
