    // Could also be "IosFileSystem" or "SharedFileSytem"
    public class DroidFileSystem : IFileSystem
    {
        public byte[] ReadAllbytes(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
