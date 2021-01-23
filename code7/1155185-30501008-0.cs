    public override string ToString()
    {
        return string.Format("{0}, {1}", 
                              MyCheckBox.CheckState.ToString(), 
                              MyNumericUpDown.Value.ToString()
                             );
    }
