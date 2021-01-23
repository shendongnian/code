	public class EmbeddedWebViewClient : WebViewClient, IValueCallback
	{
		public EmbeddedWebViewClient(WebView view)
		{
			view.Settings.JavaScriptEnabled = true;
		}
		public override void OnPageFinished(WebView view, string url)
		{
			base.OnPageFinished(view, url);
			Log.Info("SO", $"Page loaded from: {url}");
			view.EvaluateJavascript("(function() { return ('<html>'+document.getElementsByTagName('html')[0].innerHTML+'</html>'); })();", this);
		}
		public void OnReceiveValue(Java.Lang.Object value)
		{
			// "value" holds the html contents of the loaded page
			Log.Debug("SO", ((string)value).Substring(0, 40));
		}
	}
