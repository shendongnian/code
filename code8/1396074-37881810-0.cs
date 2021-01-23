    private void dataGridView1_EditingControlShowing(object sender,
                               DataGridViewEditingControlShowingEventArgs e)
    {
        DataGridView dgv = sender as DataGridView;
        string headerText = dgv.Columns[dgv.CurrentCell.ColumnIndex].HeaderText.ToString();
        DataGridViewTextBoxEditingControl tb = e.Control as DataGridViewTextBoxEditingControl;
        removeAutoComplete(tb);
        ...
