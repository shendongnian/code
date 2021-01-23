    private void deleteButton_Click(object sender, EventArgs e)
    {
        GridView view = gridControl1.FocusedView as GridView;
        if (view == null || view.SelectedRowsCount == 0) return;
    
        DataRow[] rows = new DataRow[view.SelectedRowsCount];
    
        for (int i = 0; i < view.SelectedRowsCount; i++)
            rows[i] = view.GetDataRow(view.GetSelectedRows()[i]);
    
        view.BeginSort();
    
        try
        {
            foreach (DataRow row in rows)
             row.Delete();
        }
        finally
        {
            view.EndSort();
        }
    }
