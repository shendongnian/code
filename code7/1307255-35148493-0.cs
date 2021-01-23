    private void dgComputers_EditingControlShowing(object sender, 
                             DataGridViewEditingControlShowingEventArgs e)
    {
        // mabye add checks to see if you want to make this one editable!?
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)  combo.DropDownStyle = ComboBoxStyle.DropDown;
        }
    }
