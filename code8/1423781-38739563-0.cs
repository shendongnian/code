    public string Domain1Helper(string longText)
    {
        Regex rgxUrl = new Regex(@"\"url\" :\"(.*?)\"");
        Match mUrl = rgxUrl.Match(longText);
        string url = Regex.Replace(mUrl.Groups[1].Value, @"\\", "");
        return url;
    }
