    String _rId ="";
    String _rTitle ="";
  
    void Downloadpage()
    {
        WebClient webclient = new WebClient();
    
        webclient.Headers["ContentType"] = "application/json";
        webclient.DownloadStringCompleted += wc_downloadStringCompleted;
        webclient.DownloadStringAsync(new Uri("http://client.web.net/pages_wp.php"),
    UriKind.RelativeOrAbsolute);          
    }
    
    public void wc_downloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        string lreport = e.Result.ToString();
        string lnoHTMLs = Regex.Replace(lreport, @"<[^>]+>|&nbsp;|&zwnj;|&raquo;|&laquo;|&ldquo;|\\n|\\t|", "", RegexOptions.Multiline).Trim();
        string lnoHTMLNormaliseds = Regex.Replace(lnoHTMLs, @"\s{2,}", " ");
    
    
        JArray res = JArray.Parse(lnoHTMLNormaliseds);
    news = new List<jsons>();
    
    
                string rId = res[0]["raportId"].ToString();           // ---->a
                string rTitle = res[0]["raportTitle"].ToString();     // --->b
                news.Add(new jsons() { raportId = rId, raportTitle = rTitle});
                _rId = rId;
                _rTitle = rTitle;
    
    
            Presslist.ItemsSource = news;
    }
    
    private void Add_to_cart(object sender, EventArgs e)
    {
       //values need to come here
       //_rId
       //_rTitle
    }
