    using System.IO;
    ...
    foreach (string file in Directory.EnumerateFiles(folderPath, "*.*"))
    {
        string contents = File.ReadAllText(file);
    }
