    button.MouseUp += (sender, e) =>
    {
    	if (button.Parent.ContainsFocus || e.Button != MouseButtons.Left
    		|| !button.ClientRectangle.Contains(e.Location))
    	{
    		return;
    	}
    	textBox.UseSystemPasswordChar = !textBox.UseSystemPasswordChar;
    };
    
    button.Click += delegate
    {
    	if (!button.Parent.ContainsFocus) {
    		return;
    	}
    	textBox.UseSystemPasswordChar = !textBox.UseSystemPasswordChar;
    };
