    public string[] SearchFiles(string query)
    {
        return Directory.GetFiles(
            Path.GetDirectoryName(query),
            Path.GetFileName(query));
    }
