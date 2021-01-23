    public List<string> GetAllFiles(string path)
    {
        List<string> files = new List<string>();
        foreach (string file in FindFiles(path))
        {
            files.Add(file);
        }
        return files;
    }
    
    private IEnumerable<string> FindFiles(string path)
    {
        if (Directory.Exists(path))
        {
            try
            {
                foreach (string folder in Directory.GetDirectories(path))
                {
                    foreach (string file in FindFiles(files, folder))
                    {
                        yield return file;
                    }
                }
    
                foreach (string file in Directory.GetFiles(path).ToArray())
                {
                    yield return file;
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
