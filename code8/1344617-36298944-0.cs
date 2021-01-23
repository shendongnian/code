     protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView.EditIndex = e.NewEditIndex;
        }
    protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
    
          
           string id = GridView.DataKeys[e.RowIndex].Value.ToString();
        }
