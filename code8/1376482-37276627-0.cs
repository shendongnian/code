	public abstract class SourceFileBase : ISourceFileLocation
	{
		private readonly IFileSystem _fileSystem;
	
		public SourceFileBase(IFileSystem fileSystem)
		{
			_fileSystem = fileSystem;
		}
	
        ...
	
		public void RemoveSource()
		{
			_fileSystem.DeleteFile(Uri.AbsolutePath);
		}
	
		public void Dispose()
		{
			RemoveSource();
		}
	}
