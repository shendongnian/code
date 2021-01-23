    public void CompressDirectory(
                string directory, Stream archiveStream,
                string password = "", string searchPattern = "*", bool recursion = true)
            {
            ...
    #if CS4
                files.AddRange((new DirectoryInfo(directory)).GetFiles(searchPattern).Select(fi => fi.FullName));
    #else
                foreach (FileInfo fi in (new DirectoryInfo(directory)).GetFiles(searchPattern))
                {
                    files.Add(fi.FullName);
                }
    #endif
            ...
            }
