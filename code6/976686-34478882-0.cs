     static void Main(string[] args)
     {
         var session = WebCore.CreateWebSession(new WebPreferences { WebSecurity = false });
         using (WebView webViewBrowser = WebCore.CreateWebView(1024, 768, session, WebViewType.Offscreen))
         {
             webViewBrowser.ConsoleMessage += webViewBrowser_ConsoleMessage;
             webViewBrowser.LoadingFrameComplete += webViewBrowser_LoadingFrameComplete;
 
             webViewBrowser.Source = new Uri("http://www.google.ru/");
 
             if (WebCore.UpdateState == WebCoreUpdateState.NotUpdating) WebCore.Run();
         }
     }
 
     static void webViewBrowser_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
     {
         Debug.Print("{0} at {1}: {2} at '{3}'", e.EventName, e.LineNumber, e.Message, e.Source);
     }
 
     static void webViewBrowser_LoadingFrameComplete(object sender, FrameEventArgs e)
     {
         if (!e.IsMainFrame) return;
 
         WebView webViewBrowser = sender as WebView;
 
         Console.WriteLine(String.Format("Page Title: {0}", webViewBrowser.Title));
         Console.WriteLine(String.Format("Loaded URL: {0}", webViewBrowser.Source));
 
         BitmapSurface surface = (BitmapSurface)webViewBrowser.Surface;
         surface.SaveToPNG("result.png", true);
 
         WebCore.Shutdown();
     }
