    public string name(string link)
        {
            WebClient client = new WebClient();
            string htmlCode = client.DownloadString(link);
    
    
            Regex regex = new Regex("<div class=\"fsxl fwb\">(.*)<br />");
            Match match = regex.Match(htmlCode);
            string output = match.Groups[1].ToString();
    
            return output;
        }
