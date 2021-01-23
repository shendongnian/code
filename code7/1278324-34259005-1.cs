	private void RadioButtonClicked(object sender, EventArgs e)
	{
		var radioButton = (RadioButton)sender;
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
