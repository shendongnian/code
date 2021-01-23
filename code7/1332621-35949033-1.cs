    private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (this.dataGridView1.CurrentCell == this.dataGridView1[0,0])
        {
            ComboBox cb = e.Control as ComboBox;
            if (cb != null)
            {
                cb.SelectedIndexChanged -= Cb_SelectedIndexChanged;
                // Following line needed for initial setup.
                cb.DropDownStyle = cb.SelectedIndex == 0 ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList;
                cb.SelectedIndexChanged += Cb_SelectedIndexChanged;
            }
        }
    }
    private void Cb_SelectedIndexChanged(object sender, EventArgs e)
    {
        ComboBox cb = sender as ComboBox;
        cb.DropDownStyle = cb.SelectedIndex == 0 ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList;
    }
