    FatherComboBox.SelectedIndexChanged += new System.EventHandler(FatherComboBox_SelectedIndexChanged);
    
    private void FatherComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        ComboBox comboBox = (ComboBox) sender;
    
        string FathersName = (string) combo.SelectedValue;
    
        //Code to populate childrens ages in ages combo box
    }
    
    AgesComboBox.SelectedIndexChanged += new System.EventHandler(AgesComboBox_SelectedIndexChanged);
    
    private void AgesComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        ComboBox comboBox = (ComboBox) sender;
    
        string Age = (string) ComboBox.SelectedValue;
    
        //Code to select from database where age and fathers name == values given
        textbox.Text = queryResults
    }
