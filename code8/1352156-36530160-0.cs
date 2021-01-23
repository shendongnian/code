    ComboBox editCombo = null;   // class level variable
    private void dataGridView1_EditingControlShowing(object sender, 
                    DataGridViewEditingControlShowingEventArgs e)
    {
        editCombo = e.Control as ComboBox;
        if (editCombo != null)
        {
            // here we can set its style..
            editCombo.DropDownStyle = ComboBoxStyle.DropDown;
            editCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            // sigh..:
            editCombo.TextChanged -= editCombo_TextChanged;
            editCombo.TextChanged += editCombo_TextChanged;
        }
    }
