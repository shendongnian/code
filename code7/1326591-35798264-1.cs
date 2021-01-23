    /// <summary>
    /// Represents the file info of an embedded resource
    /// </summary>
    public class EmbeddedResourceFileInfo : IFileInfo
    {
        /// <summary>
        /// Return file contents as readonly stream. Caller should dispose stream when complete.
        /// </summary>
        /// <returns>
        /// The file stream
        /// </returns>
        public Stream CreateReadStream()
        {
            return virtualFile.Open();
        }
        /// <summary>
        /// The length of the file in bytes, or -1 for a directory info
        /// </summary>
        public long Length => virtualFile.Length;
        /// <summary>
        /// The name of the file
        /// </summary>
        public string Name => virtualFile.Name;
        /// <summary>
        /// When the file was last modified
        /// </summary>
        public DateTime LastModified => virtualFile.LastModified;
        /// <summary>
        /// Returns null as these are virtual files
        /// </summary>
        public string PhysicalPath => null;
        /// <summary>
        /// True for the case TryGetDirectoryContents has enumerated a sub-directory
        /// </summary>
        public bool IsDirectory => virtualFile.IsDirectory;
        private readonly EmbeddedResourceVirtualFile virtualFile;
        /// <summary>
        /// Construct using a <see cref="EmbeddedResourceVirtualFile"/>
        /// </summary>
        /// <param name="virtualFile"></param>
        public EmbeddedResourceFileInfo(EmbeddedResourceVirtualFile virtualFile)
        {
            this.virtualFile = virtualFile;
        }
    }
