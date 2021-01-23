    private static void FolderStructure(string path)
    {
      Console.WriteLine(path);
      foreach (string item in System.IO.Directory.GetDirectories(path))
      {
        FolderStructure(item);
      }
    }
    FolderStructure(@"X:\\My\\Path");
