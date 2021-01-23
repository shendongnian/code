    private string GetUrlTitle(Uri uri)
    {
        string title = "";
        using (HttpClient client = new HttpClient())
        {
        
            var byteData = await client.GetByteArrayAsync(url);
            string html = Encoding.UTF8.GetString(byteData);
            title = Regex.Match(html, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
        }
        return title;
    }
