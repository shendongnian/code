	private void button1_Click(object sender, EventArgs e) 
	{
		Button btn = sender as Button;	//cast the sender
			
		//hide all user controls
		foreach (Control ctrl in this.Controls)
		{
			if (ctrl .GetType() == typeof(UserControl))
			{
				ctrl .Visible = false;
			}
		}
		
		//show the usercontrol saved in "Tag" of the current button
		(btn.Tag as UserControl).Visible = True;
	}
   
