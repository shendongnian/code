    webView.Download += (object sender, DownloadEventArgs de) => {
	    if (de.Mimetype=="application/pdf") {
	        var intent = new Intent (Intent.ActionView, Android.Net.Uri.Parse (de.Url));
	        webView.Context.StartActivity (intent);
        }
    };
