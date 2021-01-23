    ((CefSharp.Wpf.ChromiumWebBrowser)chromeBrowser).FrameLoadEnd += Browser_FrameLoadEnd;
 
....
    async void Browser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {            
            Console.WriteLine("cef-"+e.Url);
            if (e.Frame.IsMain)
            {                 
                string HTML = await e.Frame.GetSourceAsync();               
                Console.WriteLine(HTML);
            }
        }
