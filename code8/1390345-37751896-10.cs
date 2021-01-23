    using ....;
    [assembly: Dependency(typeof(FileHelper_Android))]
    namespace YourNamespace.Droid{
        /// <summary>
        /// Responsible for working with files on an Android device.
        /// </summary>
        internal class FileHelper_Android : IFileHelper {
            #region Constructor
            public FileHelper_Android() { }
            #endregion
    
            public string CopyFile(string sourceFile, string destinationFilename, bool overwrite = true) {
                if(!File.Exists(sourceFile)) { return string.Empty; }
                string fullFileLocation = Path.Combine(Environment.GetFolderPath (Environment.SpecialFolder.Personal), destinationFilename);
                File.Copy(sourceFile, fullFileLocation, overwrite);
                return fullFileLocation;
            }
        }
    }
