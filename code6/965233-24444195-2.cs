    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if(GridView1.Rows.Count>0)
       {
        //GridView1.Rows[0].Visible = false;
           LinkButton DeleteItemsGridRowButton=   (LinkButton) GridView1.Rows[0].FindControl("DeleteItemsGridRowButton");
           if(DeleteItemsGridRowButton!=null)
           {
            DeleteItemsGridRowButton.Visible=false
           }
       }
    }
