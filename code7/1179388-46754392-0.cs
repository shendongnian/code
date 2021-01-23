    public class BrowserRequestHandler : IRequestHandler
    {
    	public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
    	{
    		// Open in Default browser
    		if (!request.Url.StartsWith("file:"))
    		{
    			System.Diagnostics.Process.Start(request.Url);
    			return true;
    		}
    		return false;
    	}
    
    	public bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl,
    		WindowOpenDisposition targetDisposition, bool userGesture)
    	{
    		return false;
    	}
    
    	public bool OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode, string requestUrl,
    		ISslInfo sslInfo, IRequestCallback callback)
    	{
    		callback.Dispose();
    		return false;
    	}
    
    	public void OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath)
    	{
    		throw new Exception("Plugin crashed!");
    	}
    
    	public CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request,
    		IRequestCallback callback)
    	{
    		return CefReturnValue.Continue;
    	}
    
    	public bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port,
    		string realm, string scheme, IAuthCallback callback)
    	{
    		callback.Dispose();
    		return false;
    	}
    
    	public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port,
    		X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
    	{
    		callback.Dispose();
    		return false;
    	}
    
    	public void OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status)
    	{
    		throw new Exception("Browser render process is terminated!");
    	}
    
    	public bool OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize,
    		IRequestCallback callback)
    	{
    		callback.Dispose();
    		return false;
    	}
    
    	public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response,
    		ref string newUrl)
    	{
    		var url = newUrl;
    		newUrl = url;
    	}
    
    	public bool OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url)
    	{
    		return url.StartsWith("mailto");
    	}
    
    	public void OnRenderViewReady(IWebBrowser browserControl, IBrowser browser)
    	{
    		
    	}
    
    	public bool OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
    	{
    		return false;
    	}
    
    	public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request,
    		IResponse response)
    	{
    		return null;
    	}
    
    	public void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request,
    		IResponse response, UrlRequestStatus status, long receivedContentLength)
    	{
    		
    	}
    }
