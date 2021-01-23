    string conString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
    SqlConnection conn = new SqlConnection(conString);
    conn.Open();
    SqlCommand cmd = new SqlCommand("select  TOP 50000 * from users", conn);
    DataTable dt = new DataTable();
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(dt);
