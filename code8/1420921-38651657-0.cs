	public bool dirtyBool = true; //Initialize it on contructor
	private void button1_Click(object sender, EventArgs e)
	{
		if(dirtyBool)
		{
			button1.Text = "01";
		}
		else
		{
			button1.Text = "02";
		}
		dirtyBool = !dirtyBool;
	}
