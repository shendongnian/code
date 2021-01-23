    IEnumerable<string> SearchAccessibleFilesNoDistinct(string root, List<string> files)
    {
        if(files == null)
           files = new List<string>();
        foreach (var file in Directory.EnumerateFiles(root))
        {
            string extension = Path.GetExtension(file);
            if(!files.Containes(extension))
               files.Add(extension);
        }
        foreach (var subDir in Directory.EnumerateDirectories(root))
        {
            try
            {
                SearchAccessibleFilesNoDistinct(subDir, files);
            }
            catch (UnauthorizedAccessException ex)
            {
                // ...
            }
        }
        return files;
    }
