    public void PoiListFromWiki()
    {
        StringBuilder results = new StringBuilder();
        .....
        foreach (string line in ReadFile)
        {
            Dictionary<string, string> cities = new Dictionary<string, string>();
            using (var client = new HttpClient())
            {
                    ....
                    cities[line] = string.Join(";", places);
                    results.AppendLine(line + ";" + cities[line]);
            }
        }
        File.WriteAllText(path, results.ToString());
    }
