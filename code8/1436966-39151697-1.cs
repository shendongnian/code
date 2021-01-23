    ComboBox editComboBox = null;
    private void DataGridView1_EditingControlShowing(object sender, 
                               DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is ComboBox && e.ColumnIndex == 1)
        {
            editComboBox = (ComboBox)e.Control;
            editComboBox.SelectionChangeCommitted -= editComboBox_SelectionChangeCommitted;
            editComboBox.SelectionChangeCommitted += editComboBox_SelectionChangeCommitted;
        }
    }
    void editComboBox_SelectionChangeCommitted(object sender, EventArgs e)
    {
        DataGridView1[1, dataGridView5.CurrentRow.Index] = new DataGridViewTextBoxCell();
        DataGridView1[1, dataGridView5.CurrentRow.Index].Value =
                            editComboBox.SelectedItem.ToString();
        DataGridView1.EndEdit();
        DataGridView1[1, dataGridView5.CurrentRow.Index]cell1.Selected = false;
    }
