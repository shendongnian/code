    private void ExportSelectedRows()
    {
        foreach DataRow row in matExpDataGridVW.SelectedRows
                                               .Cast<DataGridViewRow>()
                                               .Select(r => r.DataBoundItem as DataRowView)
                                               .Where(drv => drv != null)
                                               .Select(drv => drv.Row)
        {
            _SelectedData.ImportRow(row);
            _OriginalData.Rows.Remove(row);
        }
    }
