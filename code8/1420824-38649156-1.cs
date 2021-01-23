    protected void repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            bool isTopHalf = (bool)e.Item.DataItem;
            GridView gvHalf = e.Item.FindControl("gvHalf") as GridView;
            string sqlQuery;
            if (isTopHalf)
            {
                sqlQuery = "SELECT TOP 50 PERCENT * FROM Clients ORDER BY ID ASC";
            }
            else
            {
                sqlQuery = "SELECT * FROM (SELECT TOP 50 PERCENT * FROM Clients ORDER BY ID DESC) BottomHalf ORDER BY ID ASC";
            }
            using (SqlConnection conn = new SqlConnection(...))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
            {
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Clients");
                gvHalf.DataSource = ds.Tables[0].DefaultView;
                gvHalf.DataBind();
            }
        }
    }
