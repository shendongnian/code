    public static void CopyFolder(string sourcePath, string destinationPath)
    {
         Directory.CreateDirectory(destinationPath);
         // Copy files first.
         foreach(var sourceFile in Directory.GetFiles(sourcePath))
         {
              string destFile = Path.Combine(destinationPath, Path.GetFileName(sourceFile));
              File.Copy(sourceFile, destFile, true);
         }
         foreach(var sourceSubPath in Directory.GetDirectories(sourcePath))
         {
              string destPath = Path.Combine(destinationPath, Path.GetFileName(sourceSubPath));
              CopyFolder(sourceSubPath, destPath);
         }
    }
