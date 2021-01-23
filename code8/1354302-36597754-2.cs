    public string GetLatestUpdate(string path)
    {
        if (!path.EndsWith("\\")) path += "\\";
        return System.IO.Directory.GetDirectories(path)
                        .Select(f => new KeyValuePair<string, long>(f, long.Parse(f.Remove(0, (path + "Update").Length))))
                        .OrderByDescending(kvp => kvp.Value)
                        .First().Key;   
    }
