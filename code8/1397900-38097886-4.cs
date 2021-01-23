    private async Task<string> RequestPageAsync(string url, string cachePath, double zoomLevel)
        {
            var tcs = new TaskCompletionSource<string>();
            var browserSettings = new BrowserSettings();
            //Reduce rendering speed to one frame per second so it's easier to take screen shots
            browserSettings.WindowlessFrameRate = 1;
            var requestContextSettings = new RequestContextSettings { CachePath = cachePath };
            // RequestContext can be shared between browser instances and allows for custom settings
            // e.g. CachePath
            using (var requestContext = new RequestContext(requestContextSettings))
            using (var browser = new ChromiumWebBrowser(url, browserSettings, requestContext))
            {
                if (zoomLevel > 1)
                {
                    browser.FrameLoadStart += (s, argsi) =>
                    {
                        var b = (ChromiumWebBrowser)s;
                        if (argsi.Frame.IsMain)
                        {
                            b.SetZoomLevel(zoomLevel);
                        }
                    };
                }
                browser.FrameLoadEnd += (s, argsi) =>
                {
                    var b = (ChromiumWebBrowser)s;
                    if (argsi.Frame.IsMain)
                    {
                        b.GetSourceAsync().ContinueWith(taskHtml =>
                        {
                            tcs.TrySetResult(taskHtml.Result);
                        });
                    }
                };
            }
            return tcs.Task.Result;
        }
        
