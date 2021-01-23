    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
    	if (dataGridView1.CurrentCell.ColumnIndex == colSourceName.Index)
    	{
    		((ComboBox)e.Control).SelectedIndexChanged -= cmb_SelectedIndexChanged;
    		((ComboBox)e.Control).SelectedIndexChanged += cmb_SelectedIndexChanged;
    	}
    }
