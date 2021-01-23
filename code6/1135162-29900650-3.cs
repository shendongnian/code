     public static void FolderNames(string path)
        {
            pathsToFind.Add(path);
            DirectoryInfo dir = new DirectoryInfo(path);
            try
            {
                foreach (DirectoryInfo info in dir.GetDirectories())
                {
                    folderNames(info.FullName);
                }
            }
            catch (Exception)
            {
            }
        }
