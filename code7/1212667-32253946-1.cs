	async void mouseEnter(object sender, MouseEventArgs e)
	{
		mouseIn = true;
		await Task.Delay(1000);
		
		if (mouseIn) 
		{
			exp.IsExpanded = true;
		}
	}
	
	void mouseLeave(object sender, MouseEventArgs e) 
	{
		mouseIn = false;
	}
