	void AddZerotoText(Control con)
	{
		foreach (Control c in con.Controls)
		{
			if (c is TextBox)
			{
				if(((TextBox)c).Text == "")
					((TextBox)c).Text = "0";
			}
		}
	}
