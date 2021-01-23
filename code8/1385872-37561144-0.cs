    private void CustomBindData()
        {
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            string sql = "SELECT * FROM CustomerDetails Where CustomerName = '" + Session["New"] + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            grid.DataBind();
        }
        protected void gdview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CustomBindData();
            grid.PageIndex = e.NewPageIndex;
            grid.DataBind();
        }
