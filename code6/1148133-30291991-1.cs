    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (dataGridView1.CurrentCell.ColumnIndex == 0 && e.Control is ComboBox)
        {
            ComboBox comboBox = e.Control as ComboBox;
            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }
    }
    private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataGridViewComboBoxEditingControl dataGridViewComboBoxEditingControl = sender as DataGridViewComboBoxEditingControl;
        object value = dataGridViewComboBoxEditingControl.SelectedValue;
        if (value != null)
        {
            int intValue = (int)dataGridViewComboBoxEditingControl.SelectedValue;
            //...
        }
    }
