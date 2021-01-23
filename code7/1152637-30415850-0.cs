	protected void okButton_Click(object sender, EventArgs e)
	{
		string firstName = lblFirstName.Text;  
		string lastName = lblLastName.Text;  
		string result = "Hello " + firstName + " " + lastName;
		resultLabel.Text = result;
	}
