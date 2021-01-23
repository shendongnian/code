	//Methods to verify and user inputs
	private bool ValidateName(string aName)
	{
		bool bStatus = true;
		// You'll need to fill this bit
		// cast or instatiate a textbox here, let's call it txt_box_name
		// 
		// cast : if you pass an object that you know is a textbox 
		// 
		// instantiate : you can create an instance of a textbox with Activator.CreateInstance
		//   more on that here: http://msdn.microsoft.com/en-us/library/system.activator.createinstance%28v=vs.110%29.aspx
		//   
		//  and then continue as normal with your generic text box field
		if (txt_box_name.Text == string.Empty)
		{
			// do something
		}
		else
		{
			// do something else
		}
		return bStatus;
	}
	private void name_Validating(object sender, CancelEventArgs e)
	{
		ValidateName("name");
		// or :
		//ValidateName("username");
	}
