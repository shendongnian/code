    private Dictionary<string, string> readConfigs(string path)
    {
        Dictionary<string, string> map = new Dictionary<string, string>();
        string[] lines = File.ReadAllLines(path);
        foreach (string line in lines)
        {
            string[] fields = line.Split(new string[] { "=" }, StringSplitOptions.None);
            if (fields.Length == 2)
            {
                string key = fields[0].Trim().ToLower();
                string value = fields[1].Trim().ToLower();
                map.Add(key, value);
            }                
        }
        
        return map;
    }
