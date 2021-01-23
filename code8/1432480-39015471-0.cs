    void dataGridView1_EditingControlShowing(object sender, 
                                             DataGridViewEditingControlShowingEventArgs e)
    {
        var comboBox = e.Control as DataGridViewComboBoxEditingControl;
        if(comboBox!=null)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
    }
