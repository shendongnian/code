    public class EmbeddedFileProvider : IFileProvider
    {
        private readonly Assembly _assembly;
        public EmbeddedFileProvider(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            _assembly = assembly;
        }
        public IFileInfo GetFileInfo(string subpath)
        {
            string fullFileName = $"{_assembly.GetName().Name}.{subpath}";
            bool isFileEmbedded = _assembly.GetManifestResourceNames().Contains(fullFileName);
            return isFileEmbedded
                ? new EmbeddedFileInfo(subpath, _assembly.GetManifestResourceStream(fullFileName))
                : (IFileInfo) new NotFoundFileInfo(subpath);
        }
        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            throw new NotImplementedException();
        }
        public IChangeToken Watch(string filter)
        {
            throw new NotImplementedException();
        }
    }
