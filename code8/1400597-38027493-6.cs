	partial class DirectoryUtils
	{
		public static IEnumerable<FileInfo> EnumerateAccessibleFiles(string path, bool allDirectories = false)
		{
			return EnumerateAccessibleDirectories(path, allDirectories).EnumerateFiles();
		}
		public static IEnumerable<FileInfo> EnumerateFiles(this IEnumerable<DirectoryInfo> source)
		{
			return source.SelectMany(di => di.EnumerateFiles());
		}
	}
