    void test()
    {
        string result = Regex.Replace(xmlString, @"</*(?<tag>.*?)>", MyMatchEvaluator);
    }
    private string MyMatchEvaluator(Match m)
    {
        string tag = m.Groups["tag"].Value;
        string result = m.Value;
        switch (tag)
        {
            case "xyz":
            case "abc":
                result = string.Empty;
                break;
                //more cases if needed
        }
        return result;
    }
