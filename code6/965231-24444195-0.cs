    protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
    {
       if(GridView1.Rows.Count>0)
       {
        GridView1.Rows[0].Visible = false;
       }
    }
