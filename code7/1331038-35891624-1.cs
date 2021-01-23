    private static void FindFile(DirectoryInfo currentDirectory, string pattern, List<FileInfo> results)
    {
        try 
        {
            results.AddRange(currentDirectory.GetFiles(pattern, SearchOption.TopDirectoryOnly));
            foreach (DirectoryInfo dir in currentDirectory.GetDirectories("*", SearchOption.TopDirectoryOnly).Where(d => d.Name != "." && d.Name != ".."))
                FindFile(dir, pattern, results);
        }
        catch
        { 
            // probably no access to directory
        }
    }
