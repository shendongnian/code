    foreach (string x in a)
    {
    
        string somePath = @"C:\test\";
        string filename = x;
        string path = Path.Combine(somePath, filename);
        string str = File.ReadAllText(path);
        str = str.Replace("AS", "");
        var lines = str.Split('\n');
        foreach(var line in lines)
        {
            var parts = line.Split(',');
            if(parts.Length > 2)
            {
                var d = parts[2];
                DateTime dateValue;
                if (DateTime.TryParseExact(d, "dd-MM-yyyy", new CultureInfo("en-US"), 
                     DateTimeStyles.None, out dateValue))
                    {
                        var dateTxt = dateValue.ToString("yyyy/mm/dd");
                          ...etc...
                         
                     }
                }
            }
            File.WriteAllText(path, str);
        }
