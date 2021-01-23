    string query = "select auction_number, auction_title from Auctions";
    using (SqlConnection myConnection = new SqlConnection(ConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand(query, myConnection))
        {
            myConnection.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dt = new DataTable();
            dt.Load(dr);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
    }
