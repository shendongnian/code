    private void dataGridView1_CellContextMenuStripNeeded(object sender, 
        DataGridViewCellContextMenuStripNeededEventArgs e)
    {
        //Check if this is column header
        if (e.RowIndex == -1)
        {
            //Show the context menu
            e.ContextMenuStrip = this.contextMenuStrip1;
            //e.ColumnIndex is the column than you right clicked on it.
        }
    }
