    private void radgridview_CellEndEdit(object sender, GridViewCellEventArgs e)
    {
        GridViewEditManager manager = sender as GridViewEditManager;
        RadGridView sendingGridView = manager?.GridViewElement?.GridControl;
        
        if (sendingGridView == null || !lst.Contains(sendingGridView))
            return; // just to be sure
    }
