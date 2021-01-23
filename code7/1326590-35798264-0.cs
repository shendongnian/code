    /// <summary>
    /// Represents a virtual file system.
    /// A wrapper around <see cref="MyCustomVirtualPathProvider"/> implementing
    /// IFileSystem for use in Owin StaticFiles.
    /// </summary>
    public class VirtualFileSystem : IFileSystem
    {
        /// <summary>
        /// Locate the path in the virtual path provider
        /// </summary>
        /// <param name="subpath">The path that identifies the file</param>
        /// <param name="fileInfo">The discovered file if any</param>
        /// <returns>
        /// True if a file was located at the given path
        /// </returns>
        public bool TryGetFileInfo(string subpath, out IFileInfo fileInfo)
        {
            MyCustomVirtualPathProvider virtualPathProvider = 
                (MyCustomVirtualPathProvider) HostingEnvironment.VirtualPathProvider;
            if (!virtualPathProvider.FileExists(subpath))
            {
                fileInfo = null;
                return false;
            }
            try
            {
                EmbeddedResourceVirtualFile virtualFile = 
                    (EmbeddedResourceVirtualFile) virtualPathProvider.GetFile(subpath);
                fileInfo = new EmbeddedResourceFileInfo(virtualFile);
                return true;
            }
            catch (InvalidCastException)
            {
                fileInfo = null;
                return false;
            }
        }
        /// <summary>
        /// Not used in our implementation
        /// </summary>
        /// <param name="subpath"></param>
        /// <param name="contents"></param>
        /// <returns></returns>
        public bool TryGetDirectoryContents(string subpath, out IEnumerable<IFileInfo> contents)
        {
            throw new NotImplementedException();
        }
    }
