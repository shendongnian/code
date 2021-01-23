    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, null, "text/html");
    LinkedResource imageResource = new LinkedResource(Imagepath + "Monitoring.png", "image/png")
    {
       ContentId = "1",
       TransferEncoding = System.Net.Mime.TransferEncoding.Base64
    };
    htmlView.LinkedResources.Add(imageResource);
    message.AlternateViews.Add(htmlView);
