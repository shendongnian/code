    public Boolean saveM1ProcessQty(string M1, string M1a)
    {
        try
        {
            string sSQL = "INSERT INTO xxx (M1, M1-1) VALUES ('@m1, @m1a')";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ToString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sSQL, conn));
                {
                    cmd.Parameters.AddWithValue("@m1", M1);
                    cmd.Parameters.AddWithValue("@m1a", M1a);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }
        catch(Exception ex)
        {
            Common.ErrorLog("M1 - " + ex.Message.ToString());
            return false;               
        }
    }
