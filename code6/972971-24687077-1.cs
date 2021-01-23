    public string ParseRawUrlAsAssetNumber(string rawUrl)
    {            
        const string pattern = @"^\\(\d+)$";
        var match = Regex.Match(rawUrl, pattern);
        if (!match.Success)
            return String.Empty;
        return match.Groups[1].Value;
    }
