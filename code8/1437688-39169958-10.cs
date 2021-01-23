	webView = new WKWebView(new CGRect(40, 100, 400, 400), new WKWebViewConfiguration());
	Add(webView);
	button = new UIButton(UIButtonType.System);
	button.Frame = new CGRect(40, 40, 100, 40);
	button.SetTitle("Fetch", UIControlState.Normal);
	Add(button);
	button.TouchUpInside += async (object sender, EventArgs e) =>
	{
		var url = new NSUrl("https://sni.velox.ch");
		var task = await NSUrlSession.SharedSession.CreateDataTaskAsync(url);
		webView.LoadHtmlString(NSString.FromData(task.Data, NSStringEncoding.UTF8), new NSUrl(""));
	};
