    void cb_Leave(object sender, EventArgs e) {
        if (cb.SelectedIndex < 0 && string.IsNullOrEmpty(cb.Text)) {
            // The Text represents the potential new item provided by the user
            // Insert validation, value generation, etc. here
            // If the proposed text becomes a new item, add it to the list
            ListItemType newItem = new ListItemType(cb.Text);
            cb.Items.Add(newItem);
    
            // And don't forget to select the new item so that the
            // SelectedIndex and SelectedItem are updated to reflect the addition
            cb.SelectedItem = newItem;
        }
    }
