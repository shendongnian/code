    protected override void OnSelectionChangeCommitted(EventArgs e)
    {
        //Put logic which you need here, and then 
        base.OnSelectionChangeCommitted(e);
        this.dataGridView.NotifyCurrentCellDirty(true);
    }
 
