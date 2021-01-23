    public interface IFileManager 
    {
        bool IsFileExists(string fileName);
        ....
    }
    public class FileManager : IFileManager
    {
         public bool IsFileExists(string fileName)
         {
            return File.Exists(fileName);
         }
    }
    public void Upload(string sourceFilePath, string targetFilePath, IFileManager fileManager)
    {
        if (!fileManager.IsFileExists(sourceFilePath))
        {
            ....
        }
    }
