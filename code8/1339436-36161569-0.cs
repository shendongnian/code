    void DirSearch(string sDir)
    {
        List<string> DirList = new List<string>();
        DirList.Add("Combustor");
        DirList.Add("INLET");
        string[] extensions = { ".c", ".h", ".isi", ".isc", ".xml", ".sheet" };
        foreach (string file in Directory.EnumerateFiles(
               sDir, "*.*", SearchOption.AllDirectories)
        .Where(s =>!DirList.Any(d => s.StartsWith(d, StringComparison.InvariantCultureIgnoreCase)) 
        && extensions.Any(ext => ext == Path.GetExtension(s))))
        {
            UpdaterUtility.UpdateFile(file);
        }
    }
