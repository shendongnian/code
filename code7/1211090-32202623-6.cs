    var concurrentBag = new ConcurrentBag<IpAndPort>(proxies);
    GetProxyWebResponse(txtUrl.Text.Trim(), concurrentBag);
    private async Task<string> GetProxyWebResponse(string url, ConcurrentBag<IpAndPort> concurrentBag)
    {	
          while (!concurrentBag.IsEmpty)
          {
               IpAndPort proxy;
               if (!concurrentBag.TryTake(out proxy)) continue;
               try
               {
    				while (true)
    			    {	
                         if (!SocketConnect(proxy.IpAddress, Convert.ToInt32(proxy.Port)))
                         {
                              break;
                         }
    				     var webProxy = new WebProxy(proxy.IpAddress, proxy.Port)
    				     {
    						  BypassProxyOnLocal = false,
    						  Credentials = CredentialCache.DefaultCredentials
    					 };
    					 var request = (HttpWebRequest)WebRequest.Create(url);
    					 request.Proxy = webProxy;    		
    					 request.Proxy = GlobalProxySelection.GetEmptyWebProxy();
    		             try
    					 {
    						  var response = (HttpWebResponse)request.GetResponse();
    						  string error;
    						  var responseFromServer = GetResponseText(response, out error);
    						  //do work with responseFromServer 
    					 }
    					 catch (Exception ex)
    					 {
    						  //ExceptionLogger.CreateFile(ex);
    					 }
    					 await Task.Delay(2000);
    			   }                        
             }
             catch (Exception ex)
             {
                  Console.WriteLine(ex.Message);
             }
             await Task.Delay(6000);
        }
        return string.Empty;
    }
