    using (var con = new SqlConnection(@"server=.\SQLExpress;Trusted_Connection=yes"))
    {
       con.Open();   
       new SqlCommand("drop database myDbName", con).ExecuteNonQuery();
       con.Close();
    }
