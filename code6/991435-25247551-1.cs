    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        var combobox = e.Control as ComboBox;
        if (combobox != null)
        {
            combobox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
            combobox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }
    }
    private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var combobox = sender as ComboBox;
        if (combobox != null)
        {
            var item = combobox.SelectedItem.ToString();
            if (!string.IsNullOrEmtpy(item))
            {
                textBox1.Text = getSum();
                // Adjust the line above as per your requirement. 
                // I don't fully understand what getSum() does as you haven't posted it
            }
        }
    }
