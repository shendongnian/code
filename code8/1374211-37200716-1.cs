    using (WebClient client = new WebClient())
    {
         var htmlData = client.DownloadData("http://www.filmweb.pl/Mroczne.Widmo");
         var htmlCode = Encoding.UTF8.GetString(htmlData);
    }
