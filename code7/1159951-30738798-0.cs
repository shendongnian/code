    public class myFSInfo
    {
        public FileSystemInfo Dir;
        public string RelativePath;
        public string BaseDirectory;
        public myFSInfo(FileSystemInfo dir, string basedir)
        {
            Dir = dir;
            BaseDirectory = basedir;
            RelativePath = Dir.FullName.Substring(basedir.Length + (basedir.Last() == '\\' ? 1 : 2));
        }
        private myFSInfo() { }
        /// <summary>
        /// Copies a FileInfo or DirectoryInfo object to the specified path, creating folders and overwriting if necessary.
        /// </summary>
        /// <param name="path"></param>
        public void CopyTo(string path)
        {
            if (Dir is FileInfo)
            {
                var f = (FileInfo)Dir;
                Directory.CreateDirectory(path.Substring(0,path.LastIndexOf("\\")));
                f.CopyTo(path,true);
            }
            else if (Dir is DirectoryInfo) Directory.CreateDirectory(path);
        }
    }
