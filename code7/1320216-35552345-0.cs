    public static IEnumerable<string> FilterFiles(string path)
    {
        foreach (string file in Directory.EnumerateFiles(path))
        {
            if (new FileInfo(file).Length < Settings.MinimumFileSize)
                File.Delete(file);
            else if (!File.Exists(Settings.ExtractFolder + "\\" + file.Substring(file.LastIndexOf('\\') + 1) + "_Extract.xml"))
                yield return file;
        }
    }
