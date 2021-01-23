    private bool isNavigated = false;
    		public CustomWebView()
    		{
    			if (Device.OS == TargetPlatform.Android)
    			{
    				// always true for android
    				isNavigated = true;
    			}
    
    			Navigated += (sender, e) =>
    			{
    				isNavigated = true;
    			};
    			Navigating += (sender, e) =>
    			{
    				if (isNavigated)
    				{
    					try
    					{
    						var uri = new Uri(e.Url);
    						Device.OpenUri(uri);
    					}
    					catch (Exception)
    					{
    					}
    
    					e.Cancel = true;
    				}
    			};
    		}
