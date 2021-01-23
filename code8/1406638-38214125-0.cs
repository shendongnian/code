    void grid_EditingControlShowing(object s, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is ComboBox)
        {
            var c = e.Control as DataGridViewComboBoxEditingControl;
            c.DropDown -= c_DropDown;
            c.DropDown += c_DropDown;
        }
    }
    void c_DropDown(object sender, EventArgs e)
    {
        if (sender is ComboBox)
        {
            var combo = sender as ComboBox;
            ((ComboBox)sender).Width = 200;
        }
    }
