    void grid_EditingControlShowing(object s, DataGridViewEditingControlShowingEventArgs e)
    {
        if (e.Control is ComboBox)
        {
            var c = e.Control as DataGridViewComboBoxEditingControl;
            c.DropDown -= c_DropDown;
            c.DropDown += c_DropDown;
        }
    }
    void c_DropDown(object s, EventArgs e)
    {
        if (s is ComboBox)
        {
            var c = s as ComboBox;
            c.DropDownWidth = c.Items.Cast<Object>()
                .Max(x => TextRenderer.MeasureText(c.GetItemText(x), c.Font).Width);
        }
    }
