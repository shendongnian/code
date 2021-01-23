    using (var vw = WebCore.CreateWebView(100,100))
    {
        vw.Source = new Uri("website");
        while (vw.IsLoading)
        {
            WebCore.Update();
        }
        var surface = (BitmapSurface)vw.Surface;
        surface.SaveToPNG("screen1.png");
        surface.Resized += (s, e) =>
        {
            // Save the updated buffer to a new PNG image.
            surface.SaveToPNG("screen2.png");
            WebCore.Shutdown();
        };
        var x = vw.ExecuteJavascriptWithResult("document.body.scrollWidth").ToString();
        var y = vw.ExecuteJavascriptWithResult("document.body.scrollHeight").ToString();
        vw.Resize(Convert.ToInt32(x), Convert.ToInt32(y));
        WebCore.Run();
    }
