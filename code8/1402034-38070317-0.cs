    foreach (Control ctr in GB.Controls)
    {
        if (ctr is TextBox)
        {
            ctr.Text = "";
        }
        else if (ctr is CheckedListBox)
        {
            CheckedListBox clb = (CheckedListBox)ctr;
            foreach (int checkedItemIndex in clb.CheckedIndices)
            {
                clb.SetItemChecked(checkedItemIndex, false);
            }
        }
        else if (ctr is CheckBox)
        {
            ((CheckBox)ctr).Checked = false;
        }
        else if (ctr is ComboBox)
        {
            ((ComboBox)ctr).SelectedIndex = 0;
        }
    }
