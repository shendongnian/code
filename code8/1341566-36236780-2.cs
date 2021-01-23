    string getNewsFrom(string url)
    {
        string content = new System.Net.WebClient().DownloadString(url);
        return content;
    }
