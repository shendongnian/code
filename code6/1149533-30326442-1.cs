    bool IsValidated = true; //will be checked on button click
    void dateTimePicker1_Validating(object sender, CancelEventArgs e)
    {
    	DateTimePicker datetimepicker = sender as DateTimePicker;
    	if (datetimepicker.Value == null)
    	{
    		errorProvider1.SetError(datetimepicker, "Required");
    		IsValidated = false;
    	}
    }
    
    void comboBox_Validating(object sender, CancelEventArgs e)
    {
    	ComboBox combo = sender as ComboBox;
    	if(combo.SelectedIndex == -1)
    	{
    		errorProvider1.SetError(combo, "Required");
    		IsValidated = false;
    	}
    }
    
    void textBox_Validating(object sender, CancelEventArgs e)
    {
    	TextBox txtbox = sender as TextBox;
    	if (txtbox.Text == "" || txtbox.Text.Length > 2)
    	{
    		errorProvider1.SetError(txtbox, "Required");
    		IsValidated = false;
    	}
    }
