    void grid_EditingControlShowing(object s, DataGridViewEditingControlShowingEventArgs e)
    {
        var comboBox = e.Control as DataGridViewComboBoxEditingControl;
        if(comboBox!=null)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
    }
