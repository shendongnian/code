    ComboBox c = new ComboBox()
    {
        DataSource = copyOfConfigDS,                            
    };
    CheckBox chkBox = new CheckBox()
    {
        Text = "Mapped"
    };
    c.SelectedIndexChanged += (eventSender, args) => 
    {
        chkBox.IsChecked = c.SelectedIndex >= 0;
    };
