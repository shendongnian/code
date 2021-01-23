	DateTime dateTimeParsed;
	if (DateTime.TryParse(textBox.Text, dateTimeParsed))
		dateTimePicker.Value = dateTimeParsed;
	else
	{
		// Handle formatting errors
	}
