    SqlConnection con = new SqlConnection("connection string");
    con.Open();
    SqlCommand cmd = new SqlCommand("exec sp_wth", con);
    cmd.Parameters.Add(new SqlParameter("@b", value));
    cmd.ExecuteNonQuery();
    con.Close();
