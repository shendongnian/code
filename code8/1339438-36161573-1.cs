    void DirSearch(string sDir)
    {
        List<string> DirList = new List<string>();
        DirList.Add("Combustor");
        DirList.Add("INLET");
        string[] extensions = { ".c", ".h", ".isi", ".isc", ".xml", ".sheet" };
        // enumerate only files in this directory (no sub directories)
        foreach (string file in Directory.EnumerateFiles(
               sDir, "*.*", SearchOption.TopDirectoryOnly).Where(s => extensions.Any(ext => ext == Path.GetExtension(s))))
        {
            UpdaterUtility.UpdateFile(file);
        }
        // now recurse the subdirectories
        foreach (string subdir in Directory.GetDirectories(
               sDir, "*", SearchOption.TopDirectoryOnly).
            Where(sd => sd != "." && sd != ".." && !DirList.Contains(sd)))
        {
            DirSearch(Path.Combine(sDir, subdir));
        }
    }
