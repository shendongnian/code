    private static void ShowAllFoldersUnder(string path, List<string> folderList)
    {
       try
       {
          if ((File.GetAttributes(path) & FileAttributes.ReparsePoint)
             != FileAttributes.ReparsePoint)
          {
             foreach (string folder in Directory.GetDirectories(path))
             {
                folderList.Add(folder);
                // Console.WriteLine(folder);
                ShowAllFoldersUnder(folder, folderList);
             }
          }
       }
       catch (UnauthorizedAccessException) { }
    }
