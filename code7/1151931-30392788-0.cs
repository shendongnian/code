	int counter;
	if(!int.TryParse(textBox1.Text, out counter))
		return;
		
	int currentCounter = 0;
	foreach(var tb in panelName.Controls.OfType<TextBox>())
	{
		if(currentCounter++ < counter)
		{
			tb.BackColor = Color.DarkRed;
			tb.Visible = true;
		}
		else
		{
			tb.Visible = false;
		}
	}
