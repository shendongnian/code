    var button = new Button {Text = "Show Out"};
    button.Click += (o, args) =>
    {
    	formName.Visible = false;
    	if (panel1.Controls.Contains(formName)) // show outside of the parent window
    	{
    		panel1.Controls.Remove(formName);
    		formName.TopLevel = true;
    		button.Text = Text = "Show In";		
    	}
    	else //flip - bring it inside the panel.
    	{
    		formName.TopLevel = false;
    		panel1.Controls.Add(formName);
    		button.Text = Text = "Show Out";		
    	}
    	formName.Show();
    };
    formName.Controls.Add(button);
