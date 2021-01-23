    [assembly: ExportRenderer (typeof (WebView), typeof (CustomWebViewRenderer))]
    public class CustomWebViewRenderer : WebViewRenderer
    {
    	protected override void OnElementChanged (VisualElementChangedEventArgs e)
    	{
    		base.OnElementChanged (e);
    		
    		if (e.OldElement == null) {
    		
    			// Need to capture the existing one so we don't loose functionality 
    			// that Xamarin.Forms already has
    			var existingDelegate = Delegate;
    			
    			// Make sure to pass the existing one to the new one
    			Delegate = new MyCustomWebViewDelegate(existingDelegate);
    		}
    	}
    }
    
    public class MyCustomWebViewDelegate : UIWebViewDelegate
    {
    	readonly UIWebViewDelegate existingDelegate;
    
    	public MyCustomWebViewDelegate(UIWebViewDelegate existing)
    	{
    		existingDelegate = existing;
    	}
    
    	public override bool ShouldStartLoad (UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
    	{
            // You can customize this instead of returning the existingDelegate method
    		return existingDelegate.ShouldStartLoad(webView, request, navigationType);
    	}
    
    	public override void LoadFailed (UIWebView webView, NSError error)
    	{
    		existingDelegate.LoadFailed(webView, error);
    	}
    
    
    	public override void LoadingFinished (UIWebView webView)
    	{
    		existingDelegate.LoadingFinished(webView);
    	}
    	
    	
    	public override void LoadStarted (UIWebView webView)
    	{
    		existingDelegate.LoadStarted(webView);
    	}
    
    }
