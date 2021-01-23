    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView mygrid = e.Row.FindControl("gvBrokerdetails") as GridView;
            mygrid.SelectedIndexChanged += new EventHandler(mygrid_SelectedIndexChanged);
        }
    }
    
    void mygrid_SelectedIndexChanged(object sender, EventArgs e)
    {
         // Write your code here
    }
