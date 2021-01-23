    private void gridView1_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
    {
        e.Handled = true;
        e.Visible = true;
    
    }
    
    private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gridView1.DataRowCount; i++)
        {
            object b = gridView1.GetRowCellValue(i, "Address");
            if (b != null && b.ToString().Contains(gridView1.FindFilterText))
            {
                gridView1.FocusedRowHandle = i;
                return;
            }
        }
    }
