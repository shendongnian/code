     #if DEBUG
     IWebProxy webProxy = System.Net.WebRequest.DefaultWebProxy;
     if (webProxy!=null && !webProxy.IsBypassed(new Uri(endpoint)))
      {
          client.Proxy = webProxy;
      }
     #endif
