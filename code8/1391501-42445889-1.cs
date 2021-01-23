    void clearTextBox(Grid gridName)
	{
		foreach (Control txtBox in gridName.Children)
		{
			if (txtBox.GetType() == typeof(TextBox))
				((TextBox)txtBox).Text = string.Empty;
			if (txtBox.GetType() == typeof(PasswordBox))
			   ((PasswordBox)txtBox).Password = string.Empty;
		}
	}
