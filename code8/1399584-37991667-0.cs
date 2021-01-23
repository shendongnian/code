    string query = "SELECT name, startdate FROM table WHERE startdate > @end_date AND name = ...";
    using (SqlConnection myConnection = new SqlConnection(ConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand(query, myConnection))
        {
            myConnection.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dt = new DataTable();
            dt.Load(dr);
            Tournament.DataSource = dt;
            Tournament.DataBind();
        }
    }
