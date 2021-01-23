       var lines = File.ReadAllLines(@"D:\temp\old.sql");
        
        for (int i = 0; i < lines.Count(); ++i)
             lines[i] = lines[i].Replace("\'\'", string.Format("\'{0}\'", i + 1));
        
        File.WriteAllLines(@"D:\temp\new.sql", lines);
