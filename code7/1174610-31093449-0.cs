    // init
    cbo.comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
    cbo.Items.Add("Select Letter") // first "empty" item
    cbo.Items.Add("A")
    cbo.Items.Add("B")
    cbo.Items.Add("C")
    // ---
    void Save()
    {
        if (cbo.SelecteIndex < 1)
        {
            MessageBox.Show("Please select letter");
            return;
        }
        // "save" code here
    }
