    bool prdg_already_updating = false;
    private void partRevisionsDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
    {
        if (e.EditAction == DataGridEditAction.Commit && !prdg_already_updating)
        {
            prdg_already_updating = true;
            (sender as DataGrid).CommitEdit();
            (sender as DataGrid).Items.Refresh();
            prdg_already_updating = false;
            m1_02DataSetPartRevisionsTableAdapter.Update(m1_02DataSet.PartRevisions);
            MessageBox.Show("Row updated");
        }
        
