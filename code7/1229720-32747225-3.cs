	private void AreControlsValid(Control.ControlCollection controls)
	{	
		foreach (Control c in controls)
		{
			if (c is Textbox && c.Visible)
			{
				if (String.IsNullOrEmpty(((Textbox)c).Text))
					return false;
			}
		   if (c.HasChildren)
			   AreControlsValid(c.Controls);
		}
		
		return true;
	}
