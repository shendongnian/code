    using System.IO;
    public static string[] ExtractPathsFromFile(string originalPath)
    {
        string[] newPaths = File.ReadAllLines(originalPath);
        string[] modified = new string[newPaths.Length];
        for (int i = 0; i < newPaths.Length; i++)
            modified[i] = Path.Combine(Path.GetDirectoryName(originalPath), newPaths[i].Trim());
        return modified;
    }
