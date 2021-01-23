    string[] projects = Directory.GetDirectories(dir, "*", SearchOptions.TopDirectoryOnly);
    string[] issues = Directory.GetFiles(dir, "*.txt", SearchOptions.AllDirectories)
    
    foreach (string project in projects)
    {
        var filteredIssues = from fi in issues where fi.Contains(project) select fi;
    
        foreach(string issue in filteredIssues)
        {
            // do something
        }
    }
