    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    dt.Rows.RemoveAt(e.RowIndex); 
    GridView1.DataSource = dt;
    GridView1.DataBind();
     }
