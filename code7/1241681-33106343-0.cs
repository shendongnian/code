    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var control = e.CommandSource as Control;
        var gridViewRow = control.NamingContainer as GridViewRow;
        int rowIndex = gridViewRow.RowIndex;
    
        ....
    }
