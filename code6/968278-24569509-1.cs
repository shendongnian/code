     public override bool ShouldOverrideUrlLoading(WebView view, System.String url) {
				// handle different requests for different type of files
				// this example handles downloads requests for files
				// everything else the webview can handle normally
				if (url.EndsWith(".pdf") || url.EndsWith(".csv")) {
					var source = Android.Net.Uri.Parse (url);
					// Make a new request pointing to the .csv url
					var request = new DownloadManager.Request(source);
					request.AllowScanningByMediaScanner();
					request.SetNotificationVisibility(Android.App.DownloadVisibility.VisibleNotifyCompleted);
					// save the file in the "Downloads" folder of SDCARD
					request.SetDestinationInExternalPublicDir(Android.OS.Environment.DirectoryDownloads, source.LastPathSegment);
					// get download service and enqueue file
					var manager = (DownloadManager) context.GetSystemService(Context.DownloadService);
					manager.Enqueue(request);
				} else if(url.StartsWith("mailto:")){
					var mt = MailTo.Parse(url);
					var i = newEmailIntent(mt.To, mt.Subject, mt.Body, mt.Cc);
					context.StartActivity(i);
					view.Reload(); // Link von Email -> active style wieder entfernen.
				} else {
					view.LoadUrl(url);
				}
				return true;                
			}
