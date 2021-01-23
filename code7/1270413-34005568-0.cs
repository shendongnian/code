    protected void GridView1_RowSelecting(object sender, GridViewDeleteEventArgs e)
    {
       var registrantId = GridView1.DataKeys[e.RowIndex];
       if(registrantId != null)
       {
           PnlEdit.Visible = true;
       }
    
    }
