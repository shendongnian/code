    using (WebClient client = new WebClient())
    {
        client.Headers.Add("Accept-Language", " en-US");
        client.Headers.Add("Accept", " text/html, application/xhtml+xml, */*");
        client.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)");
                
        XDocument xml = XDocument.Parse(client.DownloadString("http://api.arbetsformedlingen.se/af/v0/platsannonser/matchning?lanid=1&kommunid=180&yrkesid=2419&1&antalrader=10000"));
    }
