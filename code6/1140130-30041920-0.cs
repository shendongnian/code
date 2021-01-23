    foreach (Control ctrl in groupBox.Controls)
    {
        CheckBox checkBox = ctrl as CheckBox;
        ComboBox comboBox = ctrl as ComboBox;
        if (checkBox != null)   // Control is a CheckBox
        {
            if (checkBox.Checked)
            {
                // CheckBox is checked
            }
            else
            {
                // CheckBox is not checked
            }
        } 
        else if (comboBox != null)  // Control is a ComboBox
        {
            if (comboBox.Items.Count == 0)
            {
                // ComboBox is empty
            } 
            else
            {
                // ComboBox isn't empty
            }
        }
    }
