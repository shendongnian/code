	private void allButtons_Click(object sender, EventArgs e)
	{
		try
		{
			Button btn = sender as Button;
			((TextBox)Controls["textbox" + btn.Name.Replace("button", "")]).Clear();
		}
		catch (Exception ex)
		{
			//do something with the error
		}
	}
