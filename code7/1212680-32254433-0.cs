    public static string GetRedirectedUrls(string url)
    {
        StringBuilder sb = new StringBuilder();
        while (!string.IsNullOrWhiteSpace(url))
        {
            sb.AppendLine(url);
            HttpWebRequest request = HttpWebRequest.CreateHttp(url);
            request.AllowAutoRedirect = false;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                url = response.GetResponseHeader("Location");
            }
        }
        return sb.ToString();
    }
