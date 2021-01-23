    protected void Button1_Click(object sender, EventArgs e)
    {
        using (var con = new SqlConnection(@"data source=JOVAN-PC;database=aukcija_jovan_gajic;integrated security=true"))
        {
            con.Open();
            var userid = 1;
            var auctionid = 2;
    
            var cmd = new SqlCommand("usp_makebid", con);
            cmd.Parameters.AddWithValue("@userid", userid);
            cmd.Parameters.AddWithValue("@auctionid", auctionid);
            cmd.CommandType = CommandType.StoredProcedure;
    
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
