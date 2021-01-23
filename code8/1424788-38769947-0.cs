    private void ListItemsBox_DoubleClick(object sender, EventArgs e){
        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this item?",
                                    "Warning", MessageBoxButtons.YesNo, 
                                    MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
        if (dialogResult == DialogResult.Yes)
        {
            ListItemsBox.Items.Remove(ListItemsBox.SelectedItem);
        }
        else if (dialogResult == DialogResult.No)
        {
    
        }
    }
    
