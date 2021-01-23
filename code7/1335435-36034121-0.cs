    ComboBox c = new ComboBox()
    {
        DataSource = copyOfConfigDS,                            
    };
    CheckBox chkBox = new CheckBox()
    {
        Text = "Mapped"
    };
    c.SelectedIndexChanged += (sender, e) => 
    {
        chkBox.IsChecked = c.SelectedIndex >= 0;
    }
