    private Dictionary<string, string> dct = new Dictionary<string, string>();
    private string callbck(Match m)
    {
        dct.Add(m.Groups["key"].Value, m.Groups["val"].Value);
        return string.Format("{0}=\"{1}\"", m.Groups["key"].Value, m.Groups["val"].Value);
    }
    
