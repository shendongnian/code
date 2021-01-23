    public class FileInfoPassthrough // Could this be considered a facade?
    {
        /// <summary>
        /// A much more descriptive parameter name for the FileInfo constructor
        /// </summary>
        public FileInfo GetFileInfo(string fileNameOrPath)
        {
             return new FileInfo(fileNameOrPath);
        }
    }
