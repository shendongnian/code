	private void RadioButtonClicked(object sender, EventArgs e)
	{
		var radioButton = (RadioButton)sender;
        // Only run on checked items (per your comments).
        // This condition will cause the uncheck action/event to exit here.
		if (!radioButton.Checked)
        {
            return;
        }
		// Alternately, you could use a switch statement.
		if (radioButton.Name == "1")
		{
			// do something...
		}
		else if (radioButton.Name == "2")
		{
			// do something else...
		}
		// ...
	}
