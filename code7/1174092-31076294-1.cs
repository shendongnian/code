    public class FileInfoPassthrough // Could this be considered a facade?
    {
        /// <summary>
        /// A much more descriptive parameter name for the FileInfo constructor
        /// </summary>
        /// <param name="fileNameOrPath">Either the filename at the relative path of execution, or the full filename and path.</param>
        public FileInfo GetFileInfo(string fileNameOrPath)
        {
             return new FileInfo(fileNameOrPath);
        }
    }
