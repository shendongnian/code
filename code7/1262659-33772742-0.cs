    private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
    	if (dateTimePicker1.Value == DateTimePicker.MinimumDateTime)
    	{
    		dateTimePicker1.Value = DateTime.Now; // This is required in order to show current month/year when user reopens the date popup.
    		dateTimePicker1.Format = DateTimePickerFormat.Custom;
    		dateTimePicker1.CustomFormat = " ";
    	}
    	else
    	{
    		dateTimePicker1.Format = DateTimePickerFormat.Short;
    	}
    }
    
    private void Clear_Click(object sender, EventArgs e)
    {
    	dateTimePicker1.Value = DateTimePicker.MinimumDateTime;
    }
