	public static IDisposable HandleOnce(
		Action<WebBrowserDocumentCompletedEventHandler> addHandler,
		Action<WebBrowserDocumentCompletedEventHandler> removeHandler,
		WebBrowserDocumentCompletedEventHandler handler)
	{
		if (addHandler == null)
			throw new ArgumentNullException("addHandler");
		if (removeHandler == null)
			throw new ArgumentNullException("removeHandler");
		if (handler == null)
			throw new ArgumentNullException("handler");
		WebBrowserDocumentCompletedEventHandler nested = null;
		nested = (s, e) =>
		{
			removeHandler(nested);
			handler(s, e);
		};
		addHandler(nested);
		return Disposable.Create(() => removeHandler(nested));
	}
