    public string AbsoluteContent(string contentPath)
        {
            var path = Url.Content(contentPath);
            var url = new Uri(HttpContext.Current.Request.Url, path);
    
            return url.AbsoluteUri;
        }
