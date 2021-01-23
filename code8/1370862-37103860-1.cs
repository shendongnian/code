    private static List<string> DownloadLines(string hostUrl)
        {
        List<string> strContent = new List<string>();
        var webRequest = WebRequest.Create(hostUrl);
        using (var response = webRequest.GetResponse())
        using (var content = response.GetResponseStream())
        using (var reader = new StreamReader(content))
            {
                while (!reader.EndOfStream)
                {
                    strContent.Add(reader.ReadLine());
                }
            }
        return strContent;
    }
