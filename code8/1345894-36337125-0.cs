	public override bool OnJsConfirm(WebView view, string url, string message, JsResult result)
	{
		DisplayAlert("Foo", message).ContinueWith(t => {
			if(t.Result) {
				result.Confirm();
			}
			else {
				result.Cancel();
			}
		});
		return true;
	}
	public static Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
	{
		var tcs = new TaskCompletionSource<bool>();
		Device.BeginInvokeOnMainThread(async () =>
		{
			var result = await MainPage.DisplayAlert(title, message, accept, cancel);
			tcs.SetResult(result);
		});
		return tcs.Task;
	}
