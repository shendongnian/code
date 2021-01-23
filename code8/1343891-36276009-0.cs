    using (SqlConnection conn = new SqlConnection(connString))
    {
        String sql = "select count(lease_no) from XXACL_PROSPECTIVE_DATA_SAVE where mkey = @mkey";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.Add("@mkey", (int) Request.QueryString["userid"]);
        try
        {
            conn.Open();
            int rowCount = (int) cmd.ExecuteScalar();
            if (rowCount  > 0)
            {
                HidMode.Value = "M";
                HidMKey.Value = dtmkeylength.Rows[0]["Mkey"].ToString();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
