    if (!catcombobox.Items.Contains(addcattxt.Text.ToString()))
    {
        ms_combobox.Items.Add(addcattxt.Text.ToString());
    }
    else
    {
        MessageBox.Show("This category already exists.", 
                        "Invalid Operation: Duplicate Data", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
