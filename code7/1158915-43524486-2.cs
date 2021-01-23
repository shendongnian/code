    public class WebClientAsync : WebClient
    {
	    private int _timeoutMilliseconds;
	    public EdmapWebClientAsync(int timeoutSeconds)
	    {
		    _timeoutMilliseconds = timeoutSeconds * 1000;
		    Timer timer = new Timer(_timeoutMilliseconds);
		    ElapsedEventHandler handler = null;
		    handler = ((sender, args) =>
		    {
			    timer.Elapsed -= handler;
			    this.CancelAsync();
		    });
		    timer.Elapsed += handler;
		    timer.Enabled = true;
	    }
	    protected override WebRequest GetWebRequest(Uri address)
	    {
		    WebRequest request = base.GetWebRequest(address);
		    request.Timeout = _timeoutMilliseconds;
		    ((HttpWebRequest)request).ReadWriteTimeout = _timeoutMilliseconds;
		    return request;
	    }
   
        protected override voidOnDownloadProgressChanged(DownloadProgressChangedEventArgs e)
        {
            base.OnDownloadProgressChanged(e);
            timer.Reset(); //If this does not work try below
            timer.Start();
        }
    }
