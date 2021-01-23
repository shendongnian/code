	scrollView = new UIScrollView(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height));
	for (var i = 0; i < 50; i++)
	{
		var button = new UIButton(UIButtonType.System);
		button.Frame = new CGRect(40, 20 + (i * 40), 100, 40);
		button.SetTitle("Button : " + i, UIControlState.Normal);
		scrollView.Add(button);
	}
	scrollView.ContentSize = new CGSize(UIScreen.MainScreen.Bounds.Width, 50 * 40);
	Add(scrollView);
