	DateTime dateTimeParsed;
	if (DateTime.TryParse(textBox.Text, out dateTimeParsed))
		dateTimePicker.Value = dateTimeParsed;
	else
	{
		// Handle formatting errors
	}
