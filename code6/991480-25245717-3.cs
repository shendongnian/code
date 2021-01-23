    protected void mydatalist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            DataList dl = e.Item.FindControl("dl_cmt") as DataList;
            string str = gstr;
            sq.connection();
            SqlCommand cmd = new SqlCommand("select top 4 * from comment where sid='" + str + "' order by my_date desc", sq.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dl.DataSource = ds;
            dl.DataBind();
        }
    }
