	foreach(Control c in tabAppreciation.Controls)
	{
		if(c is Button)
		{
			Button button = (Button)c;
			if(button.Text=="Button text")
			{
				c.BackColor = Color.Green;
			}
		}
	}
