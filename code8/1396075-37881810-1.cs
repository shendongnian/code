     DataGridViewTextBoxEditingControl tb = null;  // keep reference
     private void dataGridView1_EditingControlShowing(object sender,
                               DataGridViewEditingControlShowingEventArgs e)
    {
        DataGridView dgv = sender as DataGridView;
        string headerText = dgv.Columns[dgv.CurrentCell.ColumnIndex].HeaderText.ToString();
        if (tb != null) removeAutoComplete(tb);  // check for null and unhook old tb
        tb = e.Control as DataGridViewTextBoxEditingControl;
        ...
