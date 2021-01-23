    private void Cb1_SelectedIndexChanged(object sender, 
		System.EventArgs e)
	{
	 		SetTextValue()
	}
	
	private void Cb2_SelectedIndexChanged(object sender, 
		System.EventArgs e)
	{
		SetTextValue()
	}
	
	private void SetTextValue ()
	(
	//hope its int value that you are binding.
		var cb1value = (int) cb1.SelectedItem;
		var cb2value = (int) cb2.SelectedItem;
	 tb1.Text = (cb1Value/cb2Value).toString();
	)
	
