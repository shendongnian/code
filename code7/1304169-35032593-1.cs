	void ClearAllText(Control con)
	{
		foreach (Control c in con.Controls)
		{
		  if (c is TextBox)
			 ((TextBox)c).Clear();
		}
	}
