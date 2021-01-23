    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        editControlWasOpened = true;
    }
    
    private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (dataGridView1 != null && dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null && editControlWasOpened )
        {
            textBox1.Text = dataGridView1.CurrentCell.Value.ToString();
        }
        valueischanged = false;
    }
