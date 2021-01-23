    foreach(Control c in groupBox.Controls)
    {
        if(c is ComboBox)
        {
             if((ComboBox) c).SelectedItem == null)
                //handle nothing entered
        }
        else if(c is CheckBox)
        {
            if((CheckBox) c).Checked)
                //handle checked
        }
    }
