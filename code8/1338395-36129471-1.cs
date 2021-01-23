    // sourcedir = path where you start searching
    public void DirSearch(string sourcedir)
    {
        try
        {
            foreach (string dir in Directory.GetDirectories(sourcedir))
            {
                DirSearch(dir);
            }
            // If you're looking for folders and not files take Directory.GetDirectories(string, string)
            foreach (string filepath in Directory.GetFiles(sourcedir, "whatever-file*wildcard-allowed*"))
            {
                // list or sth to hold all pathes where a file/folder was found
                _internalPath.Add(filepath);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
