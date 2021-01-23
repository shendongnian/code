	var button = new NSButton(new CGRect(40, 40, 50, 40));
	button.Enabled = true;
	button.Activated += (object sender, EventArgs e) =>
	{
		(sender as NSButton).Enabled = false;
	};
	View.AddSubview(button);
