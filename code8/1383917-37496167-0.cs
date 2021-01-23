    protected void button_Click(object sender, EventArgs e)
	{   
		if (ViewState.Contains("click") && ViewState["click"] == false)
		{
			ViewState["click"] = true;
			butt.Text = "you clicked me!";
		}
		else
		{
			ViewState["click"] = false;
			button.Text = "Click me again!";
		}
	}
