    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        //Check if the event is for your column, for example column 1
        if (this.dataGridView1.CurrentCell.ColumnIndex == 1)
        {
            var comboBox = e.Control as DataGridViewComboBoxEditingControl;
            comboBox.Click -= comboBox_Click;
            comboBox.Click += comboBox_Click;
        }
    }
    private void comboBox_Click(object sender, EventArgs e)
    {
        //Check if the event is for your column, for example column 1
        var comboBox = sender as DataGridViewComboBoxEditingControl;
        //use comboBox here
    }
