    public static List<Info> Load(string file)
    {
        List<Info> results = new List<Info>();
    
        string name = null;
        foreach (var line in File.ReadAllLines(file))
        {
            bool isName = false;
            string age = null;
            if (line.Contains("Name:"))
            {
                name = null;
                isName = true;
            }
    
            string value = line.Split(':')[1];
    
            if (isName)
                name = value;
            else
                age = value;
    
            if (!isName)
            {
                results.Add(new Info(name, age));
                name = null;
            }
    
        }
    
        return results;
    }
