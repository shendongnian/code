    private void btnSave_Click(object sender, EventArgs e)
    {
        DataRow[] modifiedRows = (gridView.DataSource as DataTable).Select("", "", DataViewRowState.ModifiedCurrent);
        foreach (DataRow row in modifiedRows)
        { . . .}
    }
