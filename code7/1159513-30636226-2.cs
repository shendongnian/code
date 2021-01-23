    List<string> tutionfees = new List<string>();
    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    using (SqlCommand comm = new SqlCommand("select * from fees where admno = @admno", conn))
    using (SqlDataReader rdr = comm.ExecuteReader())
    {
        while(rdr.Read())
        {
            tutionfees.Add(rdr["tutionfee"].ToString());
        }
    }
