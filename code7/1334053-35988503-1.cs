    string statement;
    switch(statement)
    {
        case (ClientAddressTextBox.Text == ""):
        MessageBox.Show("Please Enter Client Address");
        this.ActiveControl = ClientAddressTextBox; 
        break;
    
        case (InnerpathTextBox.Text == ""):
        ...
    }
