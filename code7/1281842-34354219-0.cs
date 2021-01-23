    //using System.IO;
    public void CopyMatching(string drive)
    {
        try
        {
            var backuplocation = ""; //the path where you wanna copy your files to
            var regex = new Regex(@"[A-Z]:\\Folder[0-9]{1}\\Folder[0-9]{2}\\Folder[0-9]{3}");
            var directories = new List<string>();
            foreach (var directory in Directory.EnumerateDirectories(drive))
            {
                if (regex.IsMatch(directory))
                {
                    directories.Add(directory);
                }
            }
            foreach (var directory in directories)
            {
                DirectoryCopy(directory, backuplocation, true);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
