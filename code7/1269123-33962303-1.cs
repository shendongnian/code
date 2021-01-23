    public static string[] GetImages(string fullFolderPath, string searchPattern)
    {
        var list = new List<String>();
        if (Directory.Exists(fullFolderPath))
        {
            if (String.IsNullOrEmpty(searchPattern))
            {
                searchPattern = "*.jpg";
            }
            var dir = new DirectoryInfo(fullFolderPath);
            var files = dir.GetFiles(searchPattern);
            for (int i = 0; i < files.Length; i++)
            {
                InsertImage(i + 1, 1, files[i], _sqlConnection);
                list.Add(files[i].FullName);
            }
        }
        return list.ToArray();
    }
