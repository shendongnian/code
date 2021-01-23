    void grid_AfterCellActivate(object sender, EventArgs e)
    {
        if (grid.ActiveCell != null && 
            grid.ActiveCell.Column.Index == 1 && 
            grid.ActiveCell.Row.Index == 1)
        {
            grid.ActiveCell = grid.Rows[1].Cells[2];
            // And if you want also to automatically 
            // put your cell in edit mode add this line
            grid.PerformAction(UltraGridAction.EnterEditMode);
        }
        
    }
