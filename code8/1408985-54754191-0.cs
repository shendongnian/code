	public static void LogException(Exception ex, bool redirect = true)
	{
		if (ex != null)
		{
			if (HttpContext.Current.Request.IsLocal)
			{
				throw ex;
			}
			// ignore Response.Redirect errors
			if (ex.GetType() == typeof(ThreadAbortException))
			{
				return;
			}
			var sentryApiKey = GetAppSetting("SentryIO.ApiKey");
			if (string.IsNullOrEmpty(sentryApiKey))
			{
				throw new NullReferenceException("SentryIO.ApiKey not defined as app setting.");
			}
			var ravenClient = new RavenClient(sentryApiKey);
			ravenClient.Capture(new SentryEvent(ex));
			if (redirect)
			{
				HttpContext.Current.Response.StatusCode = 404;
				HttpContext.Current.Response.Redirect("/?500-error-logged");
			}
		}
	}
