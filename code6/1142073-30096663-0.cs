    public string DownloadCSV(string url)
    {
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest .GetResponse();
    
        StreamReader streamReader = new StreamReader(httpWebResponse .GetResponseStream());
        string results = streamReader.ReadToEnd();
        streamReader .Close();
    
        return results;
    }
