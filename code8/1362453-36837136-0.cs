    public ListBox lbNames = new ListBox();
    public ComboBox cbxGender = new ComboBox();
    
    // combobox selected index changed event
    private void cbxGender_SelectedIndex_Changed(object sender, EventArgs e)
    {
        // check if there are selected items
        if(lbNames.SelectedItems.Count == 1 && cbxGender.SelectedItem != null)
        {
            // replace previous added gender
            Regex.Replace(lbNames.SelectedItem.ToString(), @".+(\([MF]\))", "");
            // append new gender
            lbNames.Items[lbNames.SelectedIndex] = lbNames.SelectedItem.ToString() + cbxGender.SelectedItem.ToString();
        }
    }
