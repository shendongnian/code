    private void Parseanddownloadfiles()
    {
        using (WebClient client = new WebClient())
        {
            client.DownloadFile(mainurl, path_exe + "\\page.html");
        }
        HtmlAgilityPack.HtmlWeb hw = new HtmlAgilityPack.HtmlWeb();
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc = hw.Load(path_exe + "\\page.html");
        foreach (HtmlAgilityPack.HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
        {
            string hrefValue = link.GetAttributeValue("href", string.Empty);
            if (hrefValue.Contains("US"))
            {
                string url = "http://www.testing.com" + hrefValue;
                parsedlinks.Add(url);
            }
            if (bgw.CancellationPending == true)
                 return;
        }
        for (int i = 0; i < parsedlinks.Count &&  bgw.CancellationPending == false; i++)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string filename = parsedlinks[i].Substring(71);
                    client.DownloadFile(parsedlinks[i], filesdirectory + "\\" + filename);
                    backgroundWorker1.ReportProgress(0, filename);
                }
            }
            catch (Exception err)
            {
                string error = err.ToString();
            }
        }
