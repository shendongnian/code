	public class IPadViewController1 : UIViewController
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			UIWebView webview = new UIWebView(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height));
			webview.ScrollView.Delegate = new ScrollViewDelegate();
			webview.ScalesPageToFit = true;
			View.AddSubview(webview);
			string urlAddress = "http://google.com";
			NSUrl url = NSUrl.FromString(urlAddress);
			//URL Requst Object
			NSUrlRequest requestObj = NSUrlRequest.FromUrl(url);
			webview.LoadRequest(requestObj);
		}
	}
