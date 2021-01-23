    public void ForEachLine(string url, Action<string> oneline)
    {
        using (var web = new WebClient())
        using (var rdr = new StreamReader(web.OpenRead(url)))
        {
            string line = null
            while ( (line = rdr.ReadLine()) != null)
            {
               oneline(line);
            }
        }
    }
