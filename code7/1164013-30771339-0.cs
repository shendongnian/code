     //Try this
     SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
    protected void btnTestDb_Click(object sender, EventArgs e)
     {
        try {
           con.Open();
            if (con.State == ConnectionState.Open)
            {
                Response.Write("Connection Open");
            }
            else
            {
                Response.Write("Connection Closed");
            }
            con.Close();
        } catch {
            Response.Write("No Connection!");
        }
    }
