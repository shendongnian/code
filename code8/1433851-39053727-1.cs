    string strConnString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
    using (SqlConnection con = new SqlConnection(strConnString))
    {
        using (SqlDataAdapter sda = new SqlDataAdapter())
        {
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            using (DataTable dt = new DataTable())
            {
                sda.Fill(dt);
                return dt;
            }
        }
    }
}`
