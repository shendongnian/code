    comboBox.SelectedIndexChanged += new EventHandler(comboBox_ComboSelectionChanged);
    
    private void comboBox_ComboSelectionChanged(object sender, EventArgs e)
          {
                if (myDGV.CurrentCell.ColumnIndex == 5)
                {
                    int selectedIndex;
                    string selectedItem;
    
                    selectedIndex = ((ComboBox)sender).SelectedIndex;  // handle an error here.
                    // get the selected item from the combobox
                    var combo = sender as ComboBox;
    
                    if (selectedIndex == -1)
                    {
                        MessageBox.Show("No value has been selected");
                    }
                    else
                    {
                        // note that SelectedItem may be null
                        selectedItem = combo.SelectedItem.ToString();
    
                        if (selectedItem != null)
                        {
                            // Your code
