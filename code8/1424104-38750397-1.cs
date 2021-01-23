	public class NavigationDelegate : NSObject, IWKNavigationDelegate
	{
		[Export("webView:didFinishNavigation:")]
		public async void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
		{
			var content = await webView.EvaluateJavaScriptAsync("(function() { return ('<html>'+document.getElementsByTagName('html')[0].innerHTML+'</html>'); })();");
			var html = FromObject(content);
			Console.WriteLine((html.ToString()).Substring(0, 40));
		}
	}
