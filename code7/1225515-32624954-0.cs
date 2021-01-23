    public TextBox FindTextBox(int index) 
    {
         // Find corresponding TextBox here 
         return Controls.Find("tbMasterParam" + index.ToString(), false).First() as TextBox;
    }
    
    ...
    
    private void displayBoardValue(byte[] BoardParameters)
    {
        uint measurement;
        string value;
        measurement = (uint)(BoardParameters[3] + (BoardParameters[2] << 8));
        value = measurement.ToString();
    
        FindTextBox(boardManager.parameter_id).Text = value;
    }
