    protected void show_comment(object sender, EventArgs e)
    {
        foreach(DataListItem item in mydatalist.Items)
        {
            int index = item.itemindex;
            
            DataList dl = (DataList) mydatalist.Items[index].FindControl("dl_cmt");
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
