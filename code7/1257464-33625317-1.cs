    [AllowAnonymous]
    public FileResult URLToImage(string url)
    {
        // In some cases you might want to pull completely different URL that is not related to your application.
        // You can do that by specifying full URL.
        UrlAsImage urlImg = new UrlAsImage(url)
        {
            FileName = Guid.NewGuid().ToString() + ".jpg",
            PageHeight = 630,
            PageWidth = 1200
        };
        Response.AddHeader("Content-Disposition", "inline; filename="+FileName);
        return File(urlImg.BuildFile(this.ControllerContext), "image/jpg");
    }
