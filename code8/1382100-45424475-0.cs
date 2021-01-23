    private static void ShowAllFoldersUnder(string path, int indent)
    {
        try
        {
            foreach (string folder in Directory.GetDirectories(path))
            {
                Console.WriteLine("{0}{1}", new string(' ', indent), Path.GetFileName(folder));
                ShowAllFoldersUnder(folder, indent + 2);
            }
        }
        catch (UnauthorizedAccessException) { }
    }
